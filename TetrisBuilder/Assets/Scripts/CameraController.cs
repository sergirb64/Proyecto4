using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraMode
    {
        Tetris,
        Movement
    }
    public CameraMode _mode = CameraMode.Movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputController();
    }

    public void SwitchCameraMode(CameraMode newMode)
    {
        switch (newMode)
        {
            case CameraMode.Tetris:
                transform.rotation = Quaternion.Euler(new Vector3(1,0,0));
                Camera.main.orthographic = true;
                _mode = CameraMode.Tetris;
                break;
            case CameraMode.Movement:
                transform.rotation = Quaternion.Euler(new Vector3(25, 0, 0));
                Camera.main.orthographic = false;
                _mode = CameraMode.Movement;
                break;
        }

    }

    private void InputController()
    {
        switch (_mode)
        {
            case CameraMode.Movement:
                InputMoveController();
                break;
        }
    }

    private void InputMoveController()
    {
        float moveHor = Input.GetAxis("Horizontal");
        if(moveHor != 0)
        {
            transform.Translate(new Vector3(moveHor, 0, 0) * Time.deltaTime * 5);
        }
    }
}
