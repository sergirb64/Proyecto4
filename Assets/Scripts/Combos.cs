using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    new int s_value;
    new int a_value;
    new int d_value;
    new int w_value;

    new int puntos;

    // Start is called before the first frame update
    void Start()
    {
        s_value = 0;
        a_value = 0;
        d_value = 0;
        w_value = 0;

        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WhenPressed()
    {
        if (Input.GetKeyDown("s"))
        {
            s_value++;
            Debug.Log("S = " + s_value);
        } else if (Input.GetKeyDown("a"))
        {
            a_value++;
            Debug.Log("A = " + a_value);
        } else if (Input.GetKeyDown("w"))
        {
            w_value++;
            Debug.Log("W = " + w_value);
        } else if (Input.GetKeyDown("d"))
        {
            d_value++;
            Debug.Log("S = " + d_value);
        }

        
    }

    void Combo1()
    {
        puntos = puntos + 50;
    }


}
