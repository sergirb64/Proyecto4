using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateRoom1 : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<Transform> posiciones;//counter par se activa la 2 counter impar se activa la 1
    public Image imagenElemento;
    public int counter = 0;


    [SerializeField]
    public GameObject TutorialUI;

    public Canvas gameChara2D;
    [SerializeField]
    private float rayCastDistance = 25f;
    [SerializeField]
    float DistanceFromCamera = 1f;

    private Vector3 touchPos;
    private Vector3 touchOrigin;



    private bool onTouchHold = false;

    private RaycastHit hitObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            touchPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(touchPos);


            //if (Physics.Raycast(ray, out hitObject, rayCastDistance))
            //{
            //    if (hitObject.transform.CompareTag("ImageElementos"))
            //    {
            //        onTouchHold = true;
            //        touchOrigin = Input.mousePosition;
            //        transform.localEulerAngles += new Vector3(0, 90, 0);
            //        counter++;
            //        if (counter > posiciones.Count-1)
            //        {
            //            counter = 0;
            //        }
            //        imagenElemento.sprite = sprites[counter];
            //        Debug.Log("Hello. This is a 3D object");
            //    }
            //}

            if (Physics.Raycast(ray, out hitObject, rayCastDistance))
            {
                if (hitObject.transform.CompareTag("ImageElementos"))
                {
                    transform.localEulerAngles += new Vector3(0, 90, 0);
                    counter++;
                    if (counter > posiciones.Count-1)
                    {
                        counter = 0;
                    }
                    imagenElemento.sprite = sprites[counter];
                    Debug.Log("Hello. This is a 2D object");
                }

            }
            //transform.localEulerAngles += new Vector3(0,90,0);
            //counter++;
            //if (counter > posiciones.Count)
            //{
            //    counter = 0;
            //}
            //imagenElemento.sprite = sprites[counter];
        }
    }
}
