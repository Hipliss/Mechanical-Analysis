using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ybotController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    Animator animator;

    //float speed = 4.0f;
    //float gravity = -9.81f;
    //float jumpHeight = 2.0f;
    float groundDistance = 0.2f;

    //bool isJumping;
    bool isGrounded;

    Vector3 velocity;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        controller.slopeLimit = 45;
        controller.stepOffset = 0.7f;
    }
    

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        
        /*
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward * z;
        controller.Move(forward * speed * Time.deltaTime);
        animator.SetFloat("Speed", forward.z);

        Vector3 sides = transform.right * x;
        controller.Move(sides * speed * Time.deltaTime);
        animator.SetFloat("Sides", sides.x);
        */
        /*
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.slopeLimit = 90;
            controller.stepOffset = 0;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
            animator.SetBool("Grounded", false);
                        isJumping = true;
        }
        else if (isJumping)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
            animator.SetBool("Grounded", false);
            isJumping = false;
        }
        else if (isGrounded)
        {
            controller.slopeLimit = 45;
            controller.stepOffset = 0.7f;
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
            animator.SetBool("Grounded", true);
        }
        */

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        /*
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        */
    }

}
