using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameLogic : MonoBehaviour
{
    [SerializeField] private int enemiesCount;
    [SerializeField] private List<EnemyAI> enemies;
    private int destroyedEnemyCount = 0;
    private AudioSource ememiesDie;

    public TextMeshProUGUI skeletonCountText;

    private Gate gate;
    public GameObject plyer;

    public MonoBehaviour charControlerScript;


    public GameObject gamePlayScreen;
    public GameObject gameOverScreen;
    public GameObject winnerScreen;

    private CameraSwitch cameraSwitch;
    private bool CamerasSwitchedAlready;




    void Start()
    {
        enemiesCount = enemies.Count;
        destroyedEnemyCount = 0;

        gate = FindObjectOfType<Gate>();
        cameraSwitch = FindObjectOfType<CameraSwitch>();
        ememiesDie = GetComponent<AudioSource>();

    }
    void Update()
    {
        UpdateScoreUI();
        ///to know if the player kill all the ememies and open
        if (destroyedEnemyCount == enemiesCount && CamerasSwitchedAlready == false)
        {
            gate.OpenTheGate();
            cameraSwitch.SwitchToSecondaryCamera();
            CamerasSwitchedAlready = true;
            Debug.Log("tha gate is open");

        }

        ///to know if the enemies saw the player from the ememes Ai script
        foreach (EnemyAI enemy in enemies)
        {
            if (enemy.IsTheGameOver == true)
            {
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);


        charControlerScript.enabled = false;
        gamePlayScreen.SetActive(false);

        Debug.Log("Game Over! The enemy saw you!");

    }

    public void Win()
    {
        winnerScreen.SetActive(true);
        gamePlayScreen.SetActive(false);

        charControlerScript.enabled = false;

    }

    ///Play Agine botton 
    public void PlayAgaine()
    {
        // Get the current scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
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

    ///to know if all ememies has daide.
    public void EnemyDestroyed(EnemyAI enemy)
    {
        destroyedEnemyCount++;
        enemies.Remove(enemy);  // Remove the destroyed enemy from the list
        ememiesDie.Play();

        Debug.Log("Enemy destroyed. Total destroyed: " + destroyedEnemyCount);
    }
    void UpdateScoreUI()
    {
        skeletonCountText.text = enemiesCount + " / " + destroyedEnemyCount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Win();

            // The player has entered the trigger zone, perform actions here
            Debug.Log("Player entered the trigger zone!");
            // You can call a method or trigger an event, for example:

        }
    }


}
