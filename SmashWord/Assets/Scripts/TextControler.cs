using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TextControler : MonoBehaviour
{
    public List<string> dialogues;
    int dialogueCount;
    public TextMeshProUGUI dialogue;
    public string[] source;
    public List<string> highlightWords;
    int count=0;
    //public class Counter
    //{

        public int WordsFromText(string text)
        {
            source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
        

            return source.Length;
        }

    //}
    // Start is called before the first frame update
    void Start()
    {
        //dialogue.GetComponent<TextMeshPro>
        Debug.Log(WordsFromText(dialogue.text));
        dialogue.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= source.Length-1)
        {
            if (count % 5 == 0)
            {
                Debug.Log(source[count] + count);

                dialogue.text += "<color=yellow>" + source[count] + "</color = yellow > ";
                highlightWords.Add(source[count]);
                count++;
            }
            else
            {
                dialogue.text +=   source[count]+ " ";
                count++;
            }
        }

        if (highlightWords==null)
        {

        }
        
    }
}
