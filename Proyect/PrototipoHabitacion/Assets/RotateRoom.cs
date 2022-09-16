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
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        if (moveHor != 0 || moveVer != 0)
        {
            Vector3 newVector = new Vector3(-moveVer, -moveHor, 0);
            Camera.main.transform.RotateAround(_room.transform.position, newVector, _speed * Time.deltaTime);
        }
    }

    private void WallController()
    {

        foreach(GameObject wall in _walls)
        {
            wall.SetActive(true);
        }

        RaycastHit hit;
        Vector3 dir = (_player.transform.position - Camera.main.transform.position).normalized;

        if (Physics.Raycast(_player.transform.position, transform.TransformDirection(-dir), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hit.collider.gameObject.SetActive(false);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

    }

    #region Buttons
    public void ResetRotation()
    {
        print("Hola");
        Camera.main.transform.rotation = _cameraRotation;
        Camera.main.transform.position = _cameraPosition;
    }
    #endregion
}
