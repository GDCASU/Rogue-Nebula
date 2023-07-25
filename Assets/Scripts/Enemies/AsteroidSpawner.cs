using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1f;
    [SerializeField] int minNumToSpawn = 1;
    [SerializeField] int maxNumToSpawn = 2;

    int numToSpawn;
    bool spawning = true;

    void SpawnAsteroid()
    {
        for(int i = 0; i < numToSpawn; i++)
        {
            var minX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
            Vector3 pos = new Vector3();
        }
    }

    public void SetSpawning(bool spawn)
    {
        spawning = spawn;
    }
}
