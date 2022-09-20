using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public LightController lightController;
   public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (lightController.time <= 0)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        text.text = "Muerto";
        yield return new WaitForSeconds(3f);
        text.text = "";
    }
}
