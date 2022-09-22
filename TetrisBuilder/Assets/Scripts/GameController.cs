using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        Build,
        Zone
    }

    public GameState _gameState = GameState.Zone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBuild(bool value)
    {
        if (value)
        {
            _gameState = GameState.Build;
        }
        else
        {
            _gameState = GameState.Zone;
        }
    }

}
