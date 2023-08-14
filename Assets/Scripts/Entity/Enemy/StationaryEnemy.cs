using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : IEnemy
{
    [SerializeField]  Transform[] ammoSpawnPoints;
    float stopwatch = 0f;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (moveDown) return;

        stopwatch += Time.deltaTime;

        if (stopwatch >= fireDelay)
        {
            Fire();
            stopwatch -= fireDelay;
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
