using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveNotVisible : MonoBehaviour
{
    float stopwatch = .25f;

    // Update is called once per frame
    void Update()
    {
        stopwatch -= Time.deltaTime;

        if(stopwatch <= 0f)
        {
            if (!GetComponentInChildren<Renderer>().isVisible)
            {
                Destroy(gameObject);
                return;
            }

            stopwatch = .25f;
        }
    }
}
