using UnityEngine;
using System.Collections;

public class DISPAROENEMIGO : MonoBehaviour
{
    private float nextActionTime = 2.0f;
    public float period = 8.0f;
    public Rigidbody projectile;
    public float tiempoVida = 0f;
    public float speed = 50;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));



        }

    }

}
   

