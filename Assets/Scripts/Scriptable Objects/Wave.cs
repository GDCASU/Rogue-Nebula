using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] public WaveDifficulty difficulty = 0;  // Just for classification (SHOULD NOT BE USED)

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
