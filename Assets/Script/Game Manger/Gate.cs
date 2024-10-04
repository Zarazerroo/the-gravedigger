using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private AudioSource doorSound;
    private Animator doorAnimator;

    void Start()
    {
        doorSound = GetComponent<AudioSource>();
        doorAnimator = GetComponent<Animator>();
    }

    public void OpenTheGate()
    {
        doorSound.Play();
        doorAnimator.SetTrigger("Open");
    }
}
