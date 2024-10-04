using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRotation;

    float smoothRotationTime = 3f;

    [SerializeField] FieldOfView fieldOfView;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;  // The player target
    [SerializeField] float stoppingDistance = 1f;

    [SerializeField] Transform portalPointA;  // First portal point
    [SerializeField] Transform portalPointB;  // Second portal point
    Transform currentDestination;  // The current destination the enemy is heading to

    public bool IsTheGameOver = false;

    public float destroyHeight = -2.5f;

    public Transform skeletonTransform;

    private GameLogic gameManager;

    private void Start()
    {
        startPos = transform.position;
        startRotation = transform.rotation;

        gameManager = FindObjectOfType<GameLogic>();

        // Start patrolling towards portal point A
        currentDestination = portalPointA;
    }

    private void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetDirection(transform.forward);

        // Check if the enemy has reached its destination
        if (Vector3.Distance(transform.position, currentDestination.position) <= stoppingDistance)
        {
            SwitchPortal();  // Switch to the other portal point once the destination is reached
        }

        Destination();

        if (agent.remainingDistance <= stoppingDistance)
        {
            // Smooth rotation when the enemy has reached its destination
            transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, Time.deltaTime * smoothRotationTime);
        }

        // Check if the enemy's Y position is below the destroyHeight
        if (skeletonTransform.position.y < destroyHeight)
        {
            NotifyDestroyed();
            Destroy(gameObject); // Destroy the enemy
        }
    }

    private void SwitchPortal()
    {
        // If the current destination is portal A, switch to portal B, and vice versa
        if (currentDestination == portalPointA)
        {
            currentDestination = portalPointB;
        }
        else
        {
            currentDestination = portalPointA;
        }
    }

    private void Destination()
    {


        Vector3 destination;

        if (fieldOfView.IsTarget)  // If the target (player) is detected, follow the player
        {

            destination = target.position;
            agent.stoppingDistance = stoppingDistance;  // Set the stopping distance to follow the player

            IsTheGameOver = true;
        }
        else  // If no target is detected, move towards the current portal
        {
            destination = currentDestination.position;
            agent.stoppingDistance = 0;  // No need to stop at a specific distance when patrolling
        }

        agent.SetDestination(destination);  // Set the agent's destination to either the player or the portal


    }


    private void NotifyDestroyed()
    {
        // Notify the GameManager that this enemy was destroyed
        gameManager.EnemyDestroyed(this);
    }

}