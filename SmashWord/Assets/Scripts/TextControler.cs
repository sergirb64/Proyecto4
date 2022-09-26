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
    bool writing;
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
        Debug.Log(WordsFromText(dialogues[0]));
        dialogue.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= source.Length-1)
        {
            writing = true;
            if (count % 5 == 0)
            {
                Debug.Log(source[count] + count);
               // int random = Random.Range(count, 4f);
               
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
        else
        {
            writing = false;
        }

        if (highlightWords.Count==0&&writing==false)
        {
            Debug.Log("null");
            dialogue.text = "";
           dialogueCount++;
            WordsFromText(dialogues[dialogueCount]);
        }
        
    }
}
