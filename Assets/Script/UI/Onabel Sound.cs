using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnabelSound : MonoBehaviour
{
    public AudioSource theAoudio;

    void OnEnable()
    {
        theAoudio.Play();
    }

}
