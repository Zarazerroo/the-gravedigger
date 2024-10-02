using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Make sure the enemy has the "Enemy" tag
        {
            // Get the Collider component of the enemy and destroy it
            Collider enemyCollider = other.GetComponent<Collider>();
            if (enemyCollider != null)
            {
                Destroy(enemyCollider); // Remove the collider so the enemy falls
            }
        }
    }
}
