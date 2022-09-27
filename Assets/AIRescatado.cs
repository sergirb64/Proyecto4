using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRescatado : MonoBehaviour
{
    GameObject Dialogo;
    private void Start()
    {
        Dialogo = transform.GetChild(0).gameObject;
        Dialogo.SetActive(true);
        Dialogo.GetComponentInChildren<TMPro.TMP_Text>().text = "La pizza con piñá es la mejoh";
    }
}
