using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject _pivot;
    private CharacterController _characterController;
    public float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _pivot.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(-_pivot.transform.position);
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");
        if (verticalMove != 0 || horizontalMove != 0)
        {
            Vector3 newVector = new Vector3(horizontalMove,0, verticalMove);
            _characterController.Move(newVector * Time.deltaTime * _speed * verticalMove);
        }
        else
        {
            _characterController.Move(Vector3.zero * Time.deltaTime * _speed * 0);
        }
    }
}
