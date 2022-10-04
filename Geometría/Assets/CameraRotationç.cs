using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationç : MonoBehaviour
{
    public float _xRotationValue;
    public float _yPositionValue;
    public float _zPositionValue;
    public Camera _otherCamera;
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
        _otherCamera.transform.localPosition = -new Vector3(distancia.x, -distancia.y - 0.64f - _yPositionValue, distancia.z + _zPositionValue);
    }
}
