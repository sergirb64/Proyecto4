using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public Animator _anim;
    public GameObject _letra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(1f);
        _anim.SetBool("Active", true);
        yield return new WaitForSeconds(1f);
        _letra.SetActive(true);
    }

    #region Buttons
    public void StartAnim()
    {
        StartCoroutine(Animation());
    }
    #endregion
}
