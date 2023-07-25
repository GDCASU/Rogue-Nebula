using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private int numberOfEnemies = 0;
    // private List<Enemy> enemyList;
    
    private void Start()
    {
        // numberOfEnemies = enemyList.count;
    }

    private void EndOfWave()
    {
        WaveManager.instance.UpdateWaveCounter();
    }
}
