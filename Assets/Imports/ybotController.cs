using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ybotController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    float speed = 4.0f;
    float gravity = -19.62f;
    float jumpHeight = 3.0f;
    float groundDistance = 0.2f;
    bool isGrounded;

    Vector3 velocity;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

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
