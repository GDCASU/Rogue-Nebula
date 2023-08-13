using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject prAsteroid;

    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] int minNumToSpawn = 1;
    [SerializeField] int maxNumToSpawn = 2;
    bool spawning = true;

    float stopwatch = 0f;

    private void Update()
    {
        if (!spawning) return;

        stopwatch += Time.deltaTime;

        if(stopwatch >= timeBetweenSpawns)
        {
            stopwatch -= timeBetweenSpawns;
            SpawnAsteroid();
        }
    }

    // Spawns a number of asteroids between minNumToSpawn and maxNumToSpawn in random locations across the top of the screen flying down in random directions towards the bottom of the screen.
    void SpawnAsteroid()
    {
        int numToSpawn = Random.Range(minNumToSpawn, maxNumToSpawn + 1);
        
        for(int i = 0; i < numToSpawn; i++)
        {
            float zValForView = Camera.main.WorldToViewportPoint(transform.position).z; // Keeps the z val of an obj that's at the right z val in viewport perspective

            float startXFromView = Random.Range(0.15f, 0.85f);
            float endXFromView = Random.Range(-.15f, 1.15f);

            Vector3 startPoint = Camera.main.ViewportToWorldPoint(new Vector3(startXFromView, 1.1f, zValForView));
            Vector3 endPoint = Camera.main.ViewportToWorldPoint(new Vector3(endXFromView, -10f, zValForView));

            Instantiate(prAsteroid, startPoint, Quaternion.FromToRotation(startPoint, endPoint));
        }
    }

    public void SetSpawning(bool spawn)
    {
        spawning = spawn;
    }
}
