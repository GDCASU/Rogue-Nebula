using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private WaveDifficulty difficulty = 0;  // Just for classification (SHOULD NOT BE USED)
    
    private List<GameObject> enemyList;
    private int numberOfEnemies = 0;
    
    private void Start()
    {
        EnemyHealth.onEnemyDeath += HandleEnemyDeath;

        enemyList = new List<GameObject>();
        AddEnemiesToList();
        numberOfEnemies = enemyList.Count;
    }

    private void AddEnemiesToList()
    {
        for (int i = 0; i < transform.childCount; i++)      // Finds all children of Wave object and stores th
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (!enemyList.Contains(child))
            {
                enemyList.Add(child);
                numberOfEnemies = enemyList.Count;
            }
        }
    }

    private void HandleEnemyDeath(GameObject enemy)
    {
        if (enemyList.Remove(enemy))    // Checks if the enemy exists in the first place than removes it
        {
            numberOfEnemies--;

            if (numberOfEnemies <= 0)           // Invoke the event to move to the next wave and end the current wa
                EndOfWave();
        }
    }

    private void EndOfWave()
    {
        WaveManager.instance.UpdateWaveCounter();
        WaveManager.instance.SpawnWave();
        //Destroy(gameObject);
    }
}
