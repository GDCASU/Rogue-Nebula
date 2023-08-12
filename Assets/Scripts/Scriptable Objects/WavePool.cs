using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WavePool", menuName = "Wave Pool")]
public class WavePool : ScriptableObject
{
    private const string WAVE_PARENT_NAME = "Waves";

    [Header("Wave Settings")]
    [SerializeField] private WaveDifficulty waveDifficulty = 0;        // Just for classification (SHOULD NOT BE USED)
    [SerializeField] private List<GameObject> waves = new List<GameObject>();

    [Header("Varient Enemies")]
    [SerializeField] private float varientMedChance = 0f;        // Default if chances not hit will just be the base enemy (easy)
    [SerializeField] private int varientMedMaxSpawn = 0;
    [SerializeField] private float varientHardChance = 0f;
    [SerializeField] private int varientHardMaxSpawn = 0;

    public void SpawnWave()
    {
        // CHECK IF WAVE SELECTED IS NULL TO PREVENT NULL REF EXC
        GameObject waveParent = GameObject.Find(WAVE_PARENT_NAME);
        // Spawn wave using RandomWaveSelect()
        GameObject wave = Instantiate(RandomWaveSelect(), waveParent.transform);

        if (!wave)
        {
            // handle errors with no waves existing in a wavepool
        }
    }

    public GameObject RandomWaveSelect()      // Select a Random Wave if it doesn't exist then use recursion to select again (highly unlikely)
    {
        if (waves.Count <= 0)       // If no waves currently selected then return null
            return null;

        int roll = Random.Range(0, waves.Count);
        if (waves[roll])
            return waves[roll];
        else
            return RandomWaveSelect();
    }
}
