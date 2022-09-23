using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TetrisController _tetris;
    public enum GameState
    {
        Build,
        Zone,
        Tetris
    }

    public GameState _gameState = GameState.Zone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameState.Build:
                BuildController();
                break;
            case GameState.Zone:
                break;
            case GameState.Tetris:
                break;
            default:
                break;
        }
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
            Camera.main.GetComponent<CameraController>().SwitchCameraMode(CameraController.CameraMode.Movement);
        }
    }

    private void BuildController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _gameState = GameState.Tetris;
            Camera.main.GetComponent<CameraController>().SwitchCameraMode(CameraController.CameraMode.Tetris);
            _tetris.StartTetris();
        }
    }

}
