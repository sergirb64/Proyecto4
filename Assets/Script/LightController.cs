using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float time=10;
    public GameObject lightGame;
    float intensity;
    float StartTime;
   public bool vivo=true;
    
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo==true)
        {
            float TimerControl = Time.deltaTime - StartTime;

            time -= TimerControl % 60;
           // Debug.Log(time);
            intensity = time /10f;
            lightGame.GetComponent<Light>().intensity = intensity;
            if (intensity <= 0)
            {

                vivo = false;
                Debug.Log("Muere");
            }
        }
      
    }
}
