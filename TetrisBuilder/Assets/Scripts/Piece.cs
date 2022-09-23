using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool _isFall = true;
    private float _nextMove = 0f;
    private int _lastX = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1f, Color.red);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int newX = _lastX - 90;
            _lastX = newX;
            transform.rotation = Quaternion.Euler(newX, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int newX = _lastX + 90;
            _lastX = newX;
            transform.rotation = Quaternion.Euler(newX, 90, 0);

        }
        else if (_isFall && Time.realtimeSinceStartup >= _nextMove)
        {
            _nextMove = Time.realtimeSinceStartup + 1f;
            DownPiece();
        }
    }

    private void DownPiece()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y) + 1, transform.position.z);
            _isFall = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isFall = false;
    }
}
