using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AbuelitaController : MonoBehaviour
{
    public GameObject _martilloAdded;
    public  bool _tieneMartillo;
    public bool misionCumplida;
    public bool puedeAndar = false;
    [Header("Dialogos")]
    public GameObject dialogoVecino;
    public TMP_Text dialogoVecinoText;
    public GameObject dialogoAbuela;
    public TMP_Text dialogoAbuelaText;
    // Start is called before the first frame update
    void Start()
    {
        puedeAndar = false;
        dialogoAbuela.SetActive(false);
        dialogoVecino.SetActive(false);
        dialogoVecinoText.text = "";
        dialogoAbuelaText.text = "";

        StartCoroutine(EmpezarDialogos());
    }
    public float distance = 50f;
    int layerMaskGround = 1 << 6;
    int layerMaskCuadro = 1 << 7;
    IEnumerator EmpezarDialogos()
    {
        yield return new WaitForSeconds(2.0f);
        dialogoAbuela.SetActive(true);
        dialogoVecino.SetActive(true);
        dialogoVecinoText.text = "Hola hola vecina, �Que le trae por aqu� hoy?";
        dialogoAbuelaText.text = "Ay filli�o, si pudieras traerme un poco de sal, estar�a agradecida";
        yield return new WaitForSeconds(5.0f);
        dialogoVecinoText.text = "Por supuestisimo que si, espere aqui un momento";
        yield return new WaitForSeconds(6.0f);//Vecino se va
        dialogoAbuelaText.text = "<Jes�s, ves lo repelente que es? esque no lo aguanto. A ver si encuentro algo por aqu� para 'evitar m�s dolores de cabeza'>";
        puedeAndar = true;
        yield return new WaitForSeconds(5.0f);
    }
    IEnumerator FinalDialogos()
    {
        dialogoAbuelaText.text = "Ay mi rey no te preocupes, cocino sin sal que me viene mejor";
        yield return new WaitForSeconds(3.0f);//Vecino se acerca
        dialogoVecinoText.text = "Pero ya se la traigo vecinita querida";
        yield return new WaitForSeconds(1.5f);
        dialogoAbuelaText.text = "Que si que si, que no te aguanto. Ups lo he dicho en voz alta?. Hasta luego cierro y me voy";
        dialogoVecinoText.text = "Pero :(";
        misionCumplida = true;
    }
    // Update is called once per frame
    void Update()
    {
        //if mouse button (left hand side) pressed instantiate a raycast
        if (Input.GetMouseButtonDown(0) && puedeAndar)
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
                    StartCoroutine(FinalDialogos());
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
        }else if (other.gameObject.CompareTag("Puerta") && misionCumplida)
        {
            //Animacion cuadro se cae y mata al vecino
        }
    }
    IEnumerator TimeToHideMartillo()
    {
        yield return new WaitForSeconds(2.0f);
        _martilloAdded.SetActive(false);
    }
}
