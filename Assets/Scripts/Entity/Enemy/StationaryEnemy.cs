using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : IEnemy
{
    [SerializeField]  Transform[] ammoSpawnPoints;

    [SerializeField] float timeBetweenFiring = 1f;
    float stopwatch = 0f;

    protected override void Start()
    {
        base.Start();
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
        
    }

    protected override void Fire()
    {
        foreach(Transform t in ammoSpawnPoints) Instantiate(ammoPrefab, t.position, t.rotation);
    }
}
