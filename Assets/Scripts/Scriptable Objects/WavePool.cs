using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WavePool", menuName = "Wave Pool")]
public class WavePool : ScriptableObject
{
    [SerializeField] private WaveDifficulty waveDifficulty = 0;        // Just for classification (SHOULD NOT BE USED)
    [SerializeField] private List<Wave> waves = new List<Wave>();
    [SerializeField] private float varientMedChance = 0f;        // Default if chances not hit will just be the base enemy (easy)
    [SerializeField] private float varientHardChance = 0f;

    public void SpawnNextWave()
    {
        // CHECK IF WAVE SELECTED IS NULL TO PREVENT NULL REF EXC
        // SPAWN WAVE AT INDEX
        // spawn wave using RandomWaveSelect()
    }

    public Wave RandomWaveSelect()      // Select a Random Wave
    {
        int roll = Random.Range(0, waves.Count);
        return waves[roll];
    }
}
