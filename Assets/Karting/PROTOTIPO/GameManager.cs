using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text volviendoACargar;
    public bool reinicio = false;
    // Start is called before the first frame update
    void Start()
    {
        reinicio = false;
        volviendoACargar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reinicio==true)
        {
            Player.life = 5;
        }
        if (Player.life <= 0)
        {
            StartCoroutine(RecargarEscena());
            volviendoACargar.enabled = true;
           
        }
      
    }
    IEnumerator RecargarEscena()
    {
        yield return new WaitForSeconds(3.0f);
         reinicio = true;
        SceneManager.LoadScene("PROTOTIPO");
        Player.playerDeath = false;
    }
}
