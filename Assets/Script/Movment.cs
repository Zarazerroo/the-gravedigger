using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public float speed = 5f; // Speed of the character
    private Rigidbody charcterRigi;
    private Animator animator;
    private bool isMoving = false;

    void Start()
    {
        // Get the Rigidbody component attached to the character
        charcterRigi = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            //isMoving = true;
            charcterRigi.velocity = Vector3.forward * speed;
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(charcterRigi.velocity);
        }

        else if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            //isMoving = true;
            charcterRigi.velocity = Vector3.back * speed;
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(charcterRigi.velocity);
        }

        else if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            //isMoving = true;
            charcterRigi.velocity = Vector3.right * speed;
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(charcterRigi.velocity);
        }

        else if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            // isMoving = true;
            charcterRigi.velocity = Vector3.left * speed;
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(charcterRigi.velocity);
        }

        else //if (!Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A))
        {
            //isMoving = false;
            charcterRigi.velocity = Vector3.zero * speed;
            animator.SetBool("isMoving", false);
        }


    }



}
