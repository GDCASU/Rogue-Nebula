using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private WaveDifficulty difficulty = 0;  // Just for classification (SHOULD NOT BE USED)
    
    private List<GameObject> enemyList;
    private int numberOfEnemies = 0;
    private int varientCounter = 0;

    private float timerTime = 5f;

    private void Start()
    {
        EnemyHealth.onEnemyDeath += HandleEnemyDeath;

        enemyList = new List<GameObject>();
        AddEnemiesToList();
        numberOfEnemies = enemyList.Count;
        RollVarients();
    }

    private void Update()
    {
        CheckTimer();
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
        if (enemyList.Remove(enemy) || enemy == null)    // Checks if the enemy exists in the first place than removes it
        {
            numberOfEnemies--;

            if (numberOfEnemies <= 0)           // Invoke the event to move to the next wave and end the current wa
                EndOfWave();
        }
    }

    private void CheckTimer()
    {
        bool isEmpty = false;

        if (timerTime > 0)
            timerTime -= Time.deltaTime;
        else
        {
            isEmpty = CheckListEmpty();
            timerTime = 5f;
        }

        if (isEmpty)
            EndOfWave();
    }

    private bool CheckListEmpty()
    {
        if (enemyList.Count == 1)
        {
            if (enemyList[0] == null)
                return true;
        }
        return false;
    }

    private void RollVarients()
    {
        foreach(GameObject enemy in enemyList) 
        {
            if (varientCounter < WaveManager.instance.GetVarientMaxSpawn())
            {
                IEnemy enemyScript = enemy.GetComponent<IEnemy>();
                if (WaveManager.instance.rollVarientHardChance())
                {
                    // MAKE THAT ENEMY HAVE HARD DIFFICULTY
                    enemyScript.SetHard();
                    varientCounter++;
}
                else if (WaveManager.instance.rollVarientMedChance())
                {
                    // MAKE THAT ENEMY HAVE MEDIUM DIFFICULTY
                    enemyScript.SetMedium();
                    varientCounter++;
                }
            }
        }
    }

    private void EndOfWave()
    {
        Debug.Log("Wave Defeated");
        WaveManager.instance.UpdateWaveCounter();
        WaveManager.instance.SpawnWave();
        Destroy(gameObject);                  // MAY USE TO CLEAN UP CLUTTER IN GAME
    }


}
