using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelitaController : MonoBehaviour
{
    public GameObject _martilloAdded;
    public  bool _tieneMartillo;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float distance = 50f;
    int layerMaskGround = 1 << 6;
    int layerMaskCuadro = 1 << 7;
    // Update is called once per frame
    void Update()
    {
        //if mouse button (left hand side) pressed instantiate a raycast
        if (Input.GetMouseButtonDown(0))
        {
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance,layerMaskGround))
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                //log hit area to the console
                Debug.Log(hit.point);
                transform.position = hit.point;
            }
            if (Physics.Raycast(ray, out hit, distance, layerMaskCuadro))
            {
                if (_tieneMartillo)
                {
                    //Animacion Martillo sacando Cuelgafacil
                    Debug.Log("Sacando cuadro");
                }
                else
                {
                    //Dialogo, no tengo nada para sacarlo
                    Debug.Log("No tengo nada para sacarllo");
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Martillo"))
        {
            _martilloAdded.SetActive(true);
            _tieneMartillo = true;
            Debug.Log("Tengo martillo" + _tieneMartillo);
            StartCoroutine(TimeToHideMartillo());
            other.gameObject.SetActive(false);
        }
    }
    IEnumerator TimeToHideMartillo()
    {
        yield return new WaitForSeconds(2.0f);
        _martilloAdded.SetActive(false);
    }
}
