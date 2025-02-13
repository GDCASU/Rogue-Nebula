using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] float aroundXSpeed = 0f;
    [SerializeField] float aroundYSpeed = 0f;
    [SerializeField] float aroundZSpeed = 0f;
    [SerializeField] float delay = 0f;

    [Header("Random Rotation")]
    [SerializeField] bool randomRotation = false;
    [SerializeField] float minAroundXSpeed = 0f, maxAroundXSpeed = 0f;
    [SerializeField] float minAroundYSpeed = 0f, maxAroundYSpeed = 0f;
    [SerializeField] float minAroundZSpeed = 0f, maxAroundZSpeed = 0f;


    // Update is called once per frame
    void Update()
    {
        if(delay > 0f)
        {
            delay -= Time.deltaTime;
            return;
        }

        if (randomRotation)
            RandomRotation();
        else
            Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(aroundXSpeed * Time.deltaTime, aroundYSpeed * Time.deltaTime, aroundZSpeed * Time.deltaTime);
    }

    private void RandomRotation()
    {
        float randAroundXSpeed = Random.Range(minAroundXSpeed, maxAroundXSpeed);
        float randAroundYSpeed = Random.Range(minAroundYSpeed, maxAroundYSpeed);
        float randAroundZSpeed = Random.Range(minAroundZSpeed, maxAroundZSpeed);

        transform.Rotate(randAroundXSpeed * Time.deltaTime, randAroundYSpeed * Time.deltaTime, randAroundZSpeed * Time.deltaTime);
    }
}
