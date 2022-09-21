using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public static int life = 5;
    public static bool playerDeath = false;
    public Camera camera1;
    public Camera camera2;
    public Rigidbody rb;

    private bool isGrounded;
    public int jumpforce = 10;
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        life = 5;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            playerDeath = true;

        }
        if (Input.GetKey(KeyCode.Q))
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpforce);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemigo")
        {
            life = life - 1;
        }
        

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
