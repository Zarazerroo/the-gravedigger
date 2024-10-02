using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterControler : MonoBehaviour
{
    public CharacterController charController;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool isMoving = false;
    private Animator animator;

    // Update is called once per frame
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direcation = new Vector3(horizontal, 0f, vertical).normalized;

        if (direcation.magnitude >= 0.1f)
        {
            float taregetAngle = Mathf.Atan2(direcation.x, direcation.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, taregetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            charController.Move(direcation * speed * Time.deltaTime);
            isMoving = true;
            animator.SetBool("isMoving", true);

        }
        else
        {

            isMoving = false;
            animator.SetBool("isMoving", false);

        }



    }




}
