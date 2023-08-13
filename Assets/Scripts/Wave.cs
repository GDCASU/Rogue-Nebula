using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private WaveDifficulty difficulty = 0;  // Just for classification (SHOULD NOT BE USED)
    
    private List<GameObject> enemyList;
    private int numberOfEnemies = 0;
    private int varientCounter = 0;

    private void Start()
    {
        EnemyHealth.onEnemyDeath += HandleEnemyDeath;

        enemyList = new List<GameObject>();
        AddEnemiesToList();
        numberOfEnemies = enemyList.Count;
        RollVarients();
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

    private void RollVarients()
    {
        foreach(GameObject enemy in enemyList) 
        {
            IEnemy enemyScript = enemy.GetComponent<IEnemy>();
            if (WaveManager.instance.rollVarientHardChance())
            {
                // MAKE THAT ENEMY HAVE HARD DIFFICULTY
                //enemyScript.damage *= hardVarientDamageMult;
                //enemyScript.health *= hardVarientHealthMult;
                //enemyScript.enemyModelList[2].SetActive(true);
            }
            else if (WaveManager.instance.rollVarientHardChance())
            {
                // MAKE THAT ENEMY HAVE MEDIUM DIFFICULTY
                //enemyScript.damage *= medVarientDamageMult;
                //enemyScript.health *= medVarientHealthMult;
                //enemyScript.enemyModelList[1].SetActive(true);
            }
            else    // ELSE LEAVE AS DEFAULT
            {
                //enemyScript.enemyModelList[0].SetActive(true);
            }
        }
    }

    private void EndOfWave()
    {
        WaveManager.instance.UpdateWaveCounter();
        WaveManager.instance.SpawnWave();
        //Destroy(gameObject);                  // MAY USE TO CLEAN UP CLUTTER IN GAME
    }


}
