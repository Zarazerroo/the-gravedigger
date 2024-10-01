using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggscript : MonoBehaviour
{
    // Reference to the prefab (hole) to be instantiated
    public GameObject holePrefab;

    // Reference to the player
    public Transform player;

    // Distance in front of the player where the hole should appear
    public float distanceInFront = 2f;

    // Ground level (the Y position where the hole should be placed)
    public float groundYPosition = 0f;

    // Method to instantiate the hole (this can be called by the button)
    public void CreateHole()
    {
        // Calculate the position in front of the player
        Vector3 spawnPosition = player.position + player.forward * distanceInFront;

        // Set the Y position to ground level
        spawnPosition.y = groundYPosition;

        // Instantiate the hole prefab at the calculated position
        Instantiate(holePrefab, spawnPosition, Quaternion.identity);
    }
}
