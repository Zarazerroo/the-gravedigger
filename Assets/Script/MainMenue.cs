using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
    public void LoadNextLevel()
    {
        // Get the current scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if there is a next level
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene by build index
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("No more levels to load!");
        }
    }
}
