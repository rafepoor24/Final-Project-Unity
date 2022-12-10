using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


//<summary>
//this class controlled the player movement 
// </summary>

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("handle the character controller")][SerializeField] private CharacterController characterController;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask; // define which are the obstacules that the player can jump - layer "floor"


    [Header("Values")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private float jumpForce = 3f;

    private float xMovement;
    private float yMovement;
    private Vector3 move;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            Jump(); // call the method in order to jump, declared below
        }

        isGrounded = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask); // check if the player is on the floor or  over other object with layer "floor"

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        xMovement = Input.GetAxis("Horizontal");
        yMovement= Input.GetAxis("Vertical");

        move=transform.right*xMovement+transform.forward*yMovement;
        characterController.Move(move* speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime; // Use the gravity for the player

        characterController.Move(velocity*Time.deltaTime);
    }

    void Jump()
    {
      
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        
    }
}
