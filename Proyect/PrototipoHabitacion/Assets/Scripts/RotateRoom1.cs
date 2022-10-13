using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateRoom1 : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<Transform> posiciones;//counter par se activa la 2 counter impar se activa la 1
    public Image imagenElemento;
    public int counter = 0;

  

    public void TocarHabitacion()
    {
        transform.localEulerAngles += new Vector3(0, 90, 0);
        counter++;
        if (counter > posiciones.Count-1)
        {
            counter = 0;
        }
        imagenElemento.sprite = sprites[counter];
    }
}
