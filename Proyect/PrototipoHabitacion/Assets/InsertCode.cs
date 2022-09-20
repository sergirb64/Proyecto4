using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsertCode : MonoBehaviour
{
    public TextMeshProUGUI checkText;


    public GameObject panel;
    bool activado;
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;

    private bool check4 = false;
    private bool check7 = false;
    private bool checkA = false;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        activado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarPanel()
    {
        if (activado == false)
        {
            panel.SetActive(true);
            activado = true;
        }
        else
        {
            panel.SetActive(false);
            activado = false;
        }

    }

    public void CheckPanel()
    {
        if(input1.text == "A" || input1.text == "7" || input1.text == "4")
        {
            if(input1.text == "A")
            {
                checkA = true;
            }else if(input1.text == "7"){
                check7 = true;
            }
            else
            {
                check4 = true;
            }
        }

        if (input2.text == "A" || input2.text == "7" || input2.text == "4")
        {
            if (input2.text == "A")
            {
                checkA = true;
            }
            else if (input2.text == "7")
            {
                check7 = true;
            }
            else
            {
                check4 = true;
            }
        }

        if (input3.text == "A" || input3.text == "7" || input3.text == "4")
        {
            if (input3.text == "A")
            {
                checkA = true;
            }
            else if (input3.text == "7")
            {
                check7 = true;
            }
            else
            {
                check4 = true;
            }
        }

        bool isCorrect = false;

        if(check4 && check7 && checkA)
        {
            isCorrect = true;
        }
        else
        {
            check4 = false;
            check7 = false;
            checkA = false;
        }

        SendMessage(isCorrect);

    } 
 
    private void SendMessage(bool isCorrect)
    {
        if (isCorrect)
        {
            checkText.text = "Correcto!";
        }
        else
        {
            checkText.text = "ERROR!";
        }
    }

}
