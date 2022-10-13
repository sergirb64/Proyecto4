using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public Image _fade;
    public GameObject fade;
    public GameObject _levelDesignCamera;
    public GameObject _cameraPlayer;
    public List<GameObject> rooms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ready()
    {
        StartCoroutine("Comenzar");
    }

    IEnumerator Comenzar()
    {
        fade.SetActive(true);
        while(_fade.color.a < 1)
        {
            _fade.color += new Color(0,0,0,0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        _levelDesignCamera.SetActive(false);
        _cameraPlayer.SetActive(true);
        foreach (GameObject room in rooms)
        {
            if (room.GetComponent<RotateRoom1>().counter % 2 == 0)
            {
                room.GetComponent<RotateRoom1>().posiciones[0].gameObject.SetActive(true);
            }
            else
            {
                room.GetComponent<RotateRoom1>().posiciones[1].gameObject.SetActive(true);
            }
            
        }
        while (_fade.color.a > 0)
        {
            _fade.color -= new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
        fade.SetActive(false);
    }
}
