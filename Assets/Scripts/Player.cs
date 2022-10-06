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
    float StartTime;
    public bool vivo = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       

        //rb.velocity = Vector3.forward * velocity*direction.sqrMagnitude;

        // transform.Translate(Vector3.forward * Time.deltaTime+transform.position);
        if (vivo == true)
        {
            float mouse = Input.GetAxis("Mouse X") * Time.deltaTime * sesibilidadRaton;
            float mouseRot = Input.GetAxis("Mouse X") * Time.deltaTime * velocityRot;
            transform.Rotate(0, mouse, 0);
            direction = new Vector3(mouseRot, 0, 1 * Time.deltaTime * velocity);
            transform.Translate(direction);

            float TimerControl = Time.deltaTime - StartTime;

            time -= TimerControl % 60;
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
            
        }
        else if (collision.gameObject.CompareTag("Hielo"))
        {
            velocity = 20;
        }
        else if (collision.gameObject.CompareTag("Platano"))
        {
            velocity = 30;
        }
        time += 10f;
        Destroy(collision.gameObject);
    }
}
