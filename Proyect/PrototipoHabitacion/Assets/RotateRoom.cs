using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public List<GameObject> _walls;
    public GameObject _player;
    public GameObject _room;
    public float _speed = 100f;
    public Quaternion _cameraRotation;
    public Vector3 _cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        _cameraPosition = Camera.main.transform.position;
        _cameraRotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        InputController();
        WallController();
    }

    private void InputController()
    {
        //Rotation Controller
        float moveHor = 0;
        float moveVer = 0;
        float forward = 0;
        float back = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveHor = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveHor = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVer = -1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVer = 1f;
        }

        if (moveHor != 0 || moveVer != 0)
        {
            Vector3 newVector = new Vector3(0, moveHor, moveVer);
            print("Vector: " + newVector);
            Camera.main.transform.RotateAround(_room.transform.position, newVector, _speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Camera.main.transform.Translate(Camera.main.transform.forward);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Camera.main.transform.Translate(-Camera.main.transform.forward);
        }



    }

    private void WallController()
    {

        foreach (GameObject wall in _walls)
        {
            wall.SetActive(true);
        }

        RaycastHit hit;
        Vector3 dir = (_player.transform.position - Camera.main.transform.position).normalized;

        if (Physics.Raycast(_player.transform.position, transform.TransformDirection(-dir), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(_player.transform.position, transform.TransformDirection(-dir), Color.yellow);
            if(hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "IgnoreCam")
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

    }

    #region Buttons
    public void ResetRotation()
    {
        Camera.main.transform.rotation = _cameraRotation;
        Camera.main.transform.position = _cameraPosition;
    }
    #endregion
}
