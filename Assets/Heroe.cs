using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    public float playerSpeed = 5;
    bool villanoMuerto;
    public GameObject ganar;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        transform.position = new Vector3(transform.position.x,0.0f,transform.position.y);
        Camera.main.transform.SetParent(transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontalMove,0,verticalMove) * playerSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Villano"))
        {
            Destroy(other.gameObject);
            villanoMuerto = true;
        }
        else if (other.gameObject.CompareTag("Rescatado") && villanoMuerto)
        {
            ganar = GameObject.FindGameObjectWithTag("Ganar");
            ganar.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
