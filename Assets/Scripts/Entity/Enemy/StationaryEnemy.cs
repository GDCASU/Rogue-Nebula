using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : IEnemy
{
    [SerializeField] Transform dest;
    [SerializeField]  Transform[] ammoSpawnPoints;

    [SerializeField] float timeBetweenFiring = 1f;
    float stopwatch = 0f;

    protected override void Start()
    {
        base.Start();

        if (dest.position.x != transform.position.x) transform.position = new Vector3(dest.position.x, transform.position.y, transform.position.z); // Move above final pos
        moveDown = true;
    }

    protected override void FixedUpdate()
    {
        if (moveDown) Move();
    }

    private void Update()
    {
        if (moveDown) return;

        stopwatch += Time.deltaTime;

        if (stopwatch >= timeBetweenFiring)
        {
            Fire();
            stopwatch -= timeBetweenFiring;
        }
    }

    protected override void Move()
    {
        float amountToMove = speed * Time.deltaTime;

        // Within range
        if (amountToMove > (transform.position - dest.position).magnitude)
        {
            amountToMove = (transform.position - dest.position).magnitude;
            moveDown = false;
        }

        transform.Translate(Vector3.down * amountToMove);
    }

    protected override void Fire()
    {
        foreach(Transform t in ammoSpawnPoints) Instantiate(ammoPrefab, t.position, t.rotation);
    }
}
