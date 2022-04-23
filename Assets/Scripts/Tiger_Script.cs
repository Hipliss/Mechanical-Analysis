using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger_Script : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;


    //float moveNum = 0;
    void Update()
    {
        transform.position = objectToFollow.position + offset;
        transform.rotation = objectToFollow.rotation;

        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            moveNum++;
            animator.SetFloat("Forward", moveNum);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            moveNum--;
            animator.SetFloat("Forward", moveNum);
        }
        */
    }
}
