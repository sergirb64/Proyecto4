using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sesibilidadRaton = 200f;
    public float velocity = 10;
    public float velocityRot = 5;
    Vector3 direction;
    Rigidbody rb;
    public float time;
    public float ObjectTime;
    float StartTime;
    public bool vivo = true;
    public GameObject patines;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartTime = Time.time;
        ObjectTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        

        //rb.velocity = Vector3.forward * velocity*direction.sqrMagnitude;

        // transform.Translate(Vector3.forward * Time.deltaTime+transform.position);
        if (vivo == true)
        {
            
            float mouse = Input.GetAxis("Mouse X") * Time.deltaTime * sesibilidadRaton;
            float mouseRot = Input.GetAxis("Mouse X") * Time.deltaTime * velocity;
            transform.Rotate(0, mouse, 0);
            direction = new Vector3(mouseRot, 0, 1 * Time.deltaTime * velocity);
            transform.Translate(direction);

            float TimerControl = Time.deltaTime - StartTime;

            time -= TimerControl % 60;
            patines.transform.localScale = new Vector3(patines.transform.localScale.x, time/ ObjectTime, patines.transform.localScale.z);
            // Debug.Log(time);

            if (time <= 0)
            {

                vivo = false;
                Debug.Log("Muere");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jabon"))
        {
            velocity = 10;
            time += 10f;
            //patines.Mes
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Hielo"))
        {
            velocity =15;
            time += 10f;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Platano"))
        {
            velocity = 20;
            time += 10f;
            Destroy(collision.gameObject);
        }
       
    }
}
