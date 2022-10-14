using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    #region Stats
    [Header("Stats")]
    public int _currentLifePoints;
    public int _maxLifePoints;
    #endregion

    #region References
    [Header("References")]
    public List<GameObject> _lightsList = new List<GameObject>();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        RestartLife();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            LightUp();
        }else if (Input.GetKeyUp(KeyCode.K))
        {
            LightDown();
        }
    }

    public void RestartLife()
    {
        _currentLifePoints = _maxLifePoints;
        UpdateLights();
    }

    public void LightDown()
    {
        _currentLifePoints--;
        if( _currentLifePoints <= 0)
        {
            _currentLifePoints = 0;
            print("Has perdido");
        }
        UpdateLights();
    }

    public void LightUp()
    {
        _currentLifePoints++;
        if( _currentLifePoints >= 6)
        {
            _currentLifePoints = _maxLifePoints;
        }
        UpdateLights();
    }

    private void UpdateLights()
    {
        foreach (GameObject light in _lightsList)
        {
            light.gameObject.SetActive(false);
        }
        for (int i = 0; i < _currentLifePoints; i++)
        {
            _lightsList[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpaceObject")
        {
            print("Comido");
            LightUp();
        }
    }
}
