using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sesibilidadRaton=200f;
    public float velocity=10;
    public float velocityRot=5;
    Vector3 direction;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouse = Input.GetAxis("Mouse X") * Time.deltaTime * sesibilidadRaton;
        float mouseRot = Input.GetAxis("Mouse X") * Time.deltaTime * velocityRot;
        transform.Rotate(0, mouse, 0);
        direction = new Vector3(mouseRot, 0, 1 * Time.deltaTime*velocity);
        transform.Translate(direction);
       
        //rb.velocity = Vector3.forward * velocity*direction.sqrMagnitude;

        // transform.Translate(Vector3.forward * Time.deltaTime+transform.position);

    }
}
