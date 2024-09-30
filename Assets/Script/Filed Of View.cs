using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledOfView : MonoBehaviour
{
    public float radius;
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstractionMask;

    public bool canSeePlayer;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FiledOfViewChek();

        }

    }

    private void FiledOfViewChek()
    {

    }

}
