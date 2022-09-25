using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    //STATS
    public int _population;
    public int _materials;
    public int _workPlaces;
    public int _workers;

    //UI
    public TextMeshProUGUI _populationText;
    public TextMeshProUGUI _materialsText;
    public TextMeshProUGUI _workText;
    public TextMeshProUGUI _workersText;

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
        UpdateUI();
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

    public void CalculatePopulation()
    {
        int currentPopulation = 0;
        GameObject[] casa = GameObject.FindGameObjectsWithTag("Casa");
        for (int i = 0; i < casa.Length; i++)
        {
            currentPopulation += casa[i].GetComponent<Casa>().GetOcupation();
        }
        _population = currentPopulation;
        UpdateUI();
    }

    public void UseMaterials(int used)
    {
        _materials -= used;
        UpdateUI();
    }

    public void AddMaterials(int added)
    {
        _materials += added;
        UpdateUI();
    }

    public void AddWorkPlaces(int added)
    {
        _workPlaces += added;
        UpdateUI();
    }

    public void UpdateUI()
    {
        _materialsText.text = _materials.ToString();
        _populationText.text = _population.ToString();
        _workText.text = _workPlaces.ToString();
        _workersText.text = _workers.ToString();
    }

}
