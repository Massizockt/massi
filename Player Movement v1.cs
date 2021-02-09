using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController characterCollider;

    public CharacterController controller;

    float movespeed;
    float sprintSpeed = 8f;
    float walkSpeed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()

    // Update is called once per frame
    void Update()
    {

        characterCollider = gameObject.GetComponent<CharacterController>();
        if (Input.GetKey(KeyCode.C))
        {
            characterCollider.height = 3.0f;
        }
        else
        
            characterCollider.height = 3.8f;
         


        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) && z == 1)
        {
            movespeed = sprintSpeed;
        }
        else
        {
            movespeed = walkSpeed;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
     }
}