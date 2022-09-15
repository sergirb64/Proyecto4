using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private int life = 3;
    void Start()
    {
        
}

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);

        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemigo")
        {
            Destroy(this.gameObject);
            life = life - 1;
        }
        

    }
}
