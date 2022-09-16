using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public  LightController lightController;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
<<<<<<< Updated upstream
        Debug.Log(groundedPlayer);
        groundedPlayer = controller.isGrounded;
=======
        
        Debug.Log(groundedPlayer);
        groundedPlayer = controller.isGrounded;

        RaycastHit hit;
        if (Physics.Raycast(transform.position,-(Vector3.up), out hit))
        {
            Debug.Log("Tocando"+ hit.distance);
            if (hit.distance < 0.6)
            {
                groundedPlayer = true;
            }
            else
            {
                groundedPlayer = false;
            }
        }
        else
        {
            Debug.Log("No");
        }

>>>>>>> Stashed changes
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("colisiona");
        if (collision.gameObject.tag=="MoreTime")
        {
            Destroy(collision.gameObject);
            Debug.Log("tag");
<<<<<<< Updated upstream
            lightController.GetComponent<LightController>().time+=5;
           
        } 
=======
            lightController.GetComponent<LightController>().time+= 5f;
           
        }

        if (collision.gameObject.tag == "LessTime")
        {
            Destroy(collision.gameObject);
            Debug.Log("enemy");
            lightController.GetComponent<LightController>().time -= 2.5f;

        }
>>>>>>> Stashed changes
    }
}
