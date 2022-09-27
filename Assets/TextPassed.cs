using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPassed : MonoBehaviour
{
    public CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(QuitarTexto());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator QuitarTexto()
    {
        yield return new WaitForSeconds(7.0f);
        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime;
            yield return null;
        }
        canvas.gameObject.SetActive(false);
    }
}
