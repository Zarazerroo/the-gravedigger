using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggscript : MonoBehaviour
{
    public GameObject holePrefab;

    public Transform player;

    public float distanceInFront = 2f;

    //public float groundYPosition = 0f;

    private Animator animator;
    public MonoBehaviour charControlerScript;

    // How long to disable the script
    public float disableDuration = 4.13f;

    public GameObject charcterModle;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();


        // Ensure that the target script is assigned
        if (charControlerScript == null)
        {
            Debug.LogError("NocharControlerScrip assigned!");
        }
    }

    public void CreateHole()
    {
        /// disable charcontrol while digging
        DisableTargetScriptForSeconds(disableDuration);

        // Calculate the position in front of the player
        Vector3 spawnPosition = player.position + player.forward * distanceInFront;

        // Set the Y position to ground level
        //spawnPosition.y = groundYPosition;

        // Instantiate the hole prefab at the calculated position
        Instantiate(holePrefab, spawnPosition, Quaternion.identity);

    }
    public void DiggAnimation()
    {
        animator.SetTrigger("Digg");
    }
    // Call this method to disable the script for a few seconds
    public void DisableTargetScriptForSeconds(float duration)
    {
        StartCoroutine(DisableScriptCoroutine(duration));
    }

    // Coroutine to disable and re-enable the target script
    private IEnumerator DisableScriptCoroutine(float duration)
    {
        // Disable the target script
        charControlerScript.enabled = false;
        animator.SetBool("finshDigging", false);

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Re-enable the target script
        charControlerScript.enabled = true;
        animator.SetBool("finshDigging", true);
        // contain the modle in proper rotaion
        charcterModle.transform.rotation = transform.rotation;
    }
}

