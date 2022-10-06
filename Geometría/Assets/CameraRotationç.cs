using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationç : MonoBehaviour
{
    public float _xRotationValue;
    public float _yPositionValue;
    public float _zPositionValue;
    public Camera _otherCamera;
    public GameObject _otherPortal;
    //public GameObject _player;
    Rigidbody _playerRB;

    // Start is called before the first frame update
    void Start()
    {
        //_playerRB = _player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion direction = Quaternion.Inverse(transform.rotation) * Camera.main.transform.rotation;
        _otherCamera.transform.localEulerAngles = new Vector3(direction.eulerAngles.x + _xRotationValue,
                                                              direction.eulerAngles.y + 180,
                                                              direction.eulerAngles.z);



        Vector3 distancia = transform.InverseTransformPoint(Camera.main.transform.position);
        _otherCamera.transform.localPosition = new Vector3(distancia.x, -distancia.y - _yPositionValue, distancia.z + _zPositionValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Colisión");
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = new Vector3(_otherPortal.transform.position.x, _otherPortal.transform.position.y, _otherPortal.transform.position.z +  -1f);
        }
    }
}
