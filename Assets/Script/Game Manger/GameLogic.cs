using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public void GameOver()
    {
        // Display game over message or trigger the game over screen.
        Debug.Log("Game Over! The enemy saw you!");

        // Example: Load game over scene
        // SceneManager.LoadScene("GameOverScene");
    }
}
