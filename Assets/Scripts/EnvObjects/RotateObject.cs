using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float aroundXSpeed = 0f;
    [SerializeField] float aroundYSpeed = 0f;
    [SerializeField] float aroundZSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(aroundXSpeed * Time.deltaTime, aroundYSpeed * Time.deltaTime, aroundZSpeed * Time.deltaTime);
    }
}
