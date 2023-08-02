using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] float refreshRate = 0.1f;
    float stopwatch = 0f;

    void LateUpdate()
    {
        stopwatch += Time.deltaTime;

        // Refresh
        if (stopwatch >= refreshRate)
        {
            transform.LookAt(Camera.main.transform);
            stopwatch -= refreshRate;
        }
    }
}
