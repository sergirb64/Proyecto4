using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool _isFall = true;
    private float _nextMove = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isFall = false;
    }
}
