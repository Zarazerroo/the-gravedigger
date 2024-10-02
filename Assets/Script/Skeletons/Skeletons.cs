using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletons : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float patrolSpeed = 2f;

    [Header("FOV Settings")]
    [SerializeField] FieldOfView fieldOfView;

    [Header("Game Over Settings")]
    [SerializeField] GameObject gameOverManager;

    private Vector3 currentTarget;
    private bool isPlayerDetected;

    private void Start()
    {
        // Start patrolling towards pointA
        currentTarget = pointA.position;
    }

    private void Update()
    {
        // Patrol between pointA and pointB
        Patrol();

        // Check if player is detected by field of view
        if (fieldOfView.IsTarget)
        {
            if (!isPlayerDetected)
            {
                isPlayerDetected = true;
                //TriggerGameOver();
            }
        }
        else
        {
            isPlayerDetected = false;
        }
    }

    private void Patrol()
    {
        // Move enemy towards the current target (point A or point B)
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, patrolSpeed * Time.deltaTime);

        // If the enemy reaches the current target, switch to the other point
        if (transform.position == currentTarget)
        {
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        }
    }

    //private void TriggerGameOver()
    // {
    //     if (gameOverManager != null)
    //  {
    // gameOverManager.GameOver();
    //   }
    //}
}

