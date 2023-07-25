using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject prAsteroid;

    [SerializeField] float spawnRate = 1f;
    [SerializeField] int minNumToSpawn = 1;
    [SerializeField] int maxNumToSpawn = 2;

    int numToSpawn;
    bool spawning = true;

    void SpawnAsteroid()
    {
        Random.Range(minNumToSpawn, maxNumToSpawn + 1);
        
        for(int i = 0; i < numToSpawn; i++)
        {
            float startXFromView = Random.Range(0.25f, 0.75f);
            float endXFromView = Random.Range(-.25f, 1.25f);

            Vector3 startPoint = Camera.main.ViewportToWorldPoint(new Vector3(startXFromView, -0.1f));
            Vector3 endPoint = Camera.main.ViewportToWorldPoint(new Vector3(endXFromView, 1.1f));

            Instantiate(prAsteroid, startPoint, Quaternion.FromToRotation(startPoint, endPoint));
        }
    }

    public void SetSpawning(bool spawn)
    {
        spawning = spawn;
    }
}
