using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMIGO : MonoBehaviour
{
    private int life = 3;
    public Transform target;
    public float speed = 500f;
    public Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position,  speed *Time.fixedDeltaTime
            );
        rig.MovePosition(pos);
        transform.LookAt(target);
        if (life <= 0)
        {
            Destroy(this.gameObject);
            
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
           
        }
        if (col.gameObject.tag == "shoot")
        {
            life = life - 1;
            
        }
     
    }
}
