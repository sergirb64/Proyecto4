using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool _isFall = true;
    private float _nextMove = 0f;
    private int _lastX = 0;
    private Rigidbody _rigidbody;
    private TetrisController _tetrisController;
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFall)
        {
            //MOVEMENT
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += Vector3.down;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(transform.position.x > _startPosition.x - 1)
                {
                    transform.position += Vector3.left;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.position.x < _startPosition.x + 1)
                {
                    transform.position += Vector3.right;
                }
            }
            //ROTATION
            if (Input.GetKeyDown(KeyCode.A))
            {
                int newX = _lastX - 90;
                _lastX = newX;
                transform.rotation = Quaternion.Euler(newX, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                int newX = _lastX + 90;
                _lastX = newX;
                transform.rotation = Quaternion.Euler(newX, 90, 0);
            }

            //DOWN
            if (Time.realtimeSinceStartup >= _nextMove)
            {
                _nextMove = Time.realtimeSinceStartup + 1f;
                DownPiece();
            }
        }

    }

    private void DownPiece()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFall && (collision.gameObject.tag == "Piece" || collision.gameObject.tag == "Ground"))
        {
            _isFall = false;
            _rigidbody.isKinematic = true;
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
            _tetrisController.CreatePiece();
        }
    }

    public void SetTetrisController(TetrisController tetris)
    {
        _tetrisController = tetris;
    }
}
