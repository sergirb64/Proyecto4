using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : SpaceObject
{
    public enum StarType
    {
        Azul,
        Blanco,
        Amarillo,
        Naranja,
        Roja
    }
    [Header("Stats")]
    public StarType _starType;
    public int _numPlanets;

    #region References
    [Header("References")]
    public List<GameObject> _planets  = new List<GameObject>();
    System.Random _rng;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitValues()
    {
        _numPlanets = _rng.Next(1, 5);
        _starType = (StarType)_rng.Next(0,4);

        for (int i = 0; i < _numPlanets; i++)
        {
            int randomIndex = _rng.Next(0, _planets.Count);
            GameObject newPlanet = Instantiate(_planets[randomIndex], transform);
        }
    }

    public void SetRng(System.Random value)
    {
        _rng = value;
    }
}
