using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ybotController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform ybot;
    [SerializeField] GameObject tiger;
    [SerializeField] float mountUp = 2.0f;

    [SerializeField] LevelController levelController;
    //[SerializeField] GameObject footsteps;

    Animator animator;
    Ybot_footsteps footsteps;
    Tiger_footsteps tigerFootsteps;

    //float speed = 4.0f;
    float gravity = -9.81f;
    float jumpHeight = 2.0f;
    float groundDistance = 0.2f;


    //bool isJumping;
    bool isGrounded;

    bool tigerActive;

    Vector3 velocity;

    [SerializeField] float timerSpeed = 1f;
    float lastTimeStamp;

    [SerializeField] float timerSpeedTiger = 1f;
    float lastTimeStampTiger;

    
    private void Start()
    {
        animator = GetComponent<Animator>();
        controller.slopeLimit = 45;
        controller.stepOffset = 0.7f;

        footsteps = GetComponent<Ybot_footsteps>();
        tigerFootsteps = GetComponent<Tiger_footsteps>();
    }


    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
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
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            controller.slopeLimit = 90;
            controller.stepOffset = 0;
        }

        if (tigerActive == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Time.time - lastTimeStamp >= timerSpeed)
                {
                    lastTimeStamp = Time.time;
                    footsteps.PlayRandom();
                }

            }

        }
        if (tigerActive == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Time.time - lastTimeStampTiger >= timerSpeedTiger)
                {
                    lastTimeStampTiger = Time.time;
                    tigerFootsteps.PlayRoundRobin();
                    tigerFootsteps.PlayRandom();
                }

            }
        }


        velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);

        levelController.CastBar();

    }

    public void Summon()
    {
        if (tigerActive == false)
        {
            tigerActive = true;
            tiger.SetActive(tigerActive);
            ybot.Translate(0, mountUp, 0);
            animator.SetBool("Mount", true);
        }
    }

    public void Desummon()
    {
        float mountDown = mountUp * -1;

        if (tigerActive == true)
        {
            tigerActive = false;
            tiger.SetActive(tigerActive);
            ybot.Translate(0, mountDown, 0);
            animator.SetBool("Mount", false);
        }
    }

}
