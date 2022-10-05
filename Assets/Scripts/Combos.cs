using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    new int s_value;
    new int a_value;
    new int d_value;
    new int w_value;
    new int space_value;

    new int puntos;

    // Start is called before the first frame update
    void Start()
    {
        ResetValues();

        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WhenPressed();
    }

    void WhenPressed()
    {
        if (Input.GetKeyDown("s"))
        {
            s_value++;
        } else if (Input.GetKeyDown("a"))
        {
            a_value++;
        } else if (Input.GetKeyDown("w"))
        {
            w_value++;
        } else if (Input.GetKeyDown("d"))
        {
            d_value++;
        } else if (Input.GetKeyDown("space"))
        {
            space_value++;
        }

        //Salto
        if (space_value == 3)
        {
            puntos = puntos + 25;

            Debug.Log("COMBO SALTO + Puntos: " + puntos);
            ResetValues();
        }

        //Combo 1
        if (a_value == 1 && d_value == 1 && w_value == 2 && s_value == 1)
        {
            puntos = puntos + 50;

            Debug.Log("COMBO PIRUETA 1 + Puntos: " + puntos);
            ResetValues();
            
        }

        //Combo 2
        if (s_value == 3 && a_value == 1 && d_value == 1 && w_value == 3)
        {
            puntos = puntos + 100;

            Debug.Log("COMBO PIRUETA 2 + Puntos: " + puntos);
            ResetValues();
        }

    }

    void ResetValues()
    {
        a_value = 0;
        s_value = 0;
        d_value = 0;
        w_value = 0;
        space_value = 0;
    }
}
