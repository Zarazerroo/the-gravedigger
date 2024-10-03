using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;  // Assign your Main Camera
    public Camera secondaryCamera;  // Assign the Secondary Camera

    public float switchDuration = 3f;  // Time to switch to the secondary camera (in seconds)

    private void Start()
    {
        // Make sure the Main Camera is active at the start
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;

        secondaryCamera.clearFlags = CameraClearFlags.Skybox;
    }

    // Call this method to switch cameras for a set amount of time
    public void SwitchToSecondaryCamera()
    {
        StartCoroutine(SwitchCameraCoroutine());
    }

    private IEnumerator SwitchCameraCoroutine()
    {
        // Disable the Main Camera and enable the Secondary Camera
        mainCamera.enabled = false;
        secondaryCamera.enabled = true;

        // Wait for the specified duration
        yield return new WaitForSeconds(switchDuration);

        // Switch back to the Main Camera
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }
}



