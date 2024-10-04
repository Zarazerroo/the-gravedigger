using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diggingbutton : MonoBehaviour
{
    // Reference to the button
    public Button myButton;

    // Duration to disable the button
    public float disableDuration = 4.0f;

    // Digging SFX
    public AudioSource DigggingSound;

    void Start()
    {
        // Ensure the button is assigned
        if (myButton == null)
        {
            myButton = GetComponent<Button>();
        }

        // Get Digging SFX from component
        DigggingSound = GetComponent<AudioSource>();

        // Add a listener to the button click event
        myButton.onClick.AddListener(() => DisableButtonForSeconds(disableDuration));
        myButton.onClick.AddListener(() => PlaySFX());

    }

    // Method to disable the button for a certain number of seconds
    public void DisableButtonForSeconds(float duration)
    {
        StartCoroutine(DisableButtonCoroutine(duration));
    }

    // Coroutine to disable the button and re-enable it after the duration
    private IEnumerator DisableButtonCoroutine(float duration)
    {
        // Disable the button
        myButton.interactable = false;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Re-enable the button
        myButton.interactable = true;
    }
    
    // Play the SFX
    public void PlaySFX()
    {
        DigggingSound.Play();
    }
}
