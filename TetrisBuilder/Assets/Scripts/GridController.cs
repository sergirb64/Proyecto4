using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject _selectedArea;
    public bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _selectedArea.SetActive(_isActive);

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
            _selectedArea.transform.position = hit.point;
        }

    }

    public void ActiveGridController()
    {
        _isActive = !_isActive;
    }

}
