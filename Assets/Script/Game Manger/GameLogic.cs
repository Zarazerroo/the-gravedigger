using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{
    [SerializeField] private int enemiesCount;
    [SerializeField] private List<EnemyAI> enemies;
    public GameObject plyer;

    public MonoBehaviour charControlerScript;


    public GameObject gamePlayScreen;
    public GameObject gameOverScreen;
    public GameObject winnerScreen;




    void Start()
    {

    }
    void Update()
    {

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


        //charControlerScript.enabled = false;
        gamePlayScreen.SetActive(false);

        Debug.Log("Game Over! The enemy saw you!");

    }

    public void Win()
    {
        winnerScreen.SetActive(true);
        gamePlayScreen.SetActive(false);

        charControlerScript.enabled = false;

    }


    public void PlayAgaine()
    {
        SceneManager.LoadScene("Alzhraa", LoadSceneMode.Single);
    }

}
