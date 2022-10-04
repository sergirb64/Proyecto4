using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sesibilidadRaton=120f;
    public float velocity;
    Vector3 moveInput;
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
        transform.Rotate(0, mouse, 0);
        moveInput = new Vector3(mouse, 0, 1);
        rb.velocity = Vector3.forward * velocity*moveInput.sqrMagnitude;
       // transform.Translate(Vector3.forward * Time.deltaTime+transform.position);
       
    }
}
