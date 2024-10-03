using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{
    [SerializeField] private int enemiesCount;
    [SerializeField] private List<EnemyAI> enemies;
    private int destroyedEnemyCount = 0;

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

        gate = FindObjectOfType<Gate>();
        cameraSwitch = FindObjectOfType<CameraSwitch>();

    }
    void Update()
    {
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
        SceneManager.LoadScene("Alzhraa", LoadSceneMode.Single);
    }


    ///to know if all ememies has daide.
    public void EnemyDestroyed(EnemyAI enemy)
    {
        destroyedEnemyCount++;
        enemies.Remove(enemy);  // Remove the destroyed enemy from the list

        Debug.Log("Enemy destroyed. Total destroyed: " + destroyedEnemyCount);
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
