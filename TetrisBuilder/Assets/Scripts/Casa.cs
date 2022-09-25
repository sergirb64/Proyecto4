using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : Build
{
    public GameObject _citizen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCitizens()
    {
        for (int i = 0; i < _currentOcupation; i++)
        {
            GameObject newCitizen = Instantiate(_citizen);
        }
    }

}
