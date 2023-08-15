using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LandmineEnemy : IEnemy
{
    float direction = 0;

    [SerializeField] float timeBetweenFiring = 1f;
    float stopwatch = 0f;
    float stopwatchMove = 0f;

    Vector3 lastDestination;
    Vector3 destination;
    float totalDistance = -1f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (moveDown) return;

        Move();
    }

    private void LateUpdate()
    {
        if (moveDown) return;   // Wait until done moving down.

        stopwatch += Time.deltaTime;

        // Shoot
        if(stopwatch >= timeBetweenFiring)
        {
            stopwatch -= timeBetweenFiring;

            Fire();
        }
    }

    protected override void Move()
    {
        if (totalDistance == -1f) SetDestination();
        if (transform.position == destination) SetDestination();

        stopwatchMove += Time.deltaTime;
        float percentage = (speed * stopwatchMove) / totalDistance;

        transform.position = Vector3.Lerp(lastDestination, destination, percentage);
    }

    void SetDestination()
    {
        float randX = Random.Range(0f, 1f);
        float randY = Random.Range(0f, 1f);
        float camZPos = Camera.main.WorldToViewportPoint(transform.position).z;

        lastDestination = transform.position;
        destination = Camera.main.ViewportToWorldPoint(new Vector3(randX, randY, camZPos));
        stopwatchMove = 0f;
        totalDistance = (lastDestination - destination).magnitude;
    }
}
