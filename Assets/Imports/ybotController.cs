using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ybotController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    Animator animator;

    float speed = 4.0f;
    float gravity = -19.62f;
    float jumpHeight = 3.0f;
    float groundDistance = 0.2f;
    bool isGrounded;

    Vector3 velocity;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward * z;
        controller.Move(forward * speed * Time.deltaTime);
        animator.SetFloat("Speed", forward.z);

        Vector3 sides = transform.right * x;
        controller.Move(sides * speed * Time.deltaTime);
        animator.SetFloat("Sides", sides.x);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.slopeLimit = 90;
            controller.stepOffset = 0;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if (isGrounded)
        {
            controller.slopeLimit = 45;
            controller.stepOffset = 0.7f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
