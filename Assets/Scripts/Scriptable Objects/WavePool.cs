using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WavePool", menuName = "Wave Pool")]
public class WavePool : ScriptableObject
{
    [SerializeField] public WaveDifficulty waveDifficulty = 0;         // Just for classification (NOT USED)
    [SerializeField] public List<Wave> waves = new List<Wave>();
    [SerializeField] public float varientChance = 0f;

    public void SpawnNextWave()
    {
        // SPAWN WAVE AT INDEX
        // spawn wave using RandomWaveSelect()
    }

    public Wave RandomWaveSelect()      // Select a Random Wave
    {
        int roll = Random.Range(0, waves.Count);
        return waves[roll];
    }
}
