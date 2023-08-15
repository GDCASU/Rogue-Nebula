using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public enum WaveDifficulty
{
    easy = 0,
    medium = 1,
    hard = 2
}

public class WaveManager : MonoBehaviour
{
    private const string WAVE_PARENT_NAME = "Waves";

    public static WaveManager instance;

    [Header("Wave Pools")]
    [SerializeField] private int changePoolAfterWaves = 20;
    [SerializeField] private List<WavePool> wavePools = new List<WavePool>();

    [Header("Difficulty")]
    [SerializeField] public WaveDifficulty currentDifficulty = 0;       // Should not be tampered with; just for testing

    private WavePool currentWavePool = null;
    private int waveCounter = 1;
    private int waveCountMult = 1; // Used to keep track of when to change WavePools

    public static event Action<int> onWaveStart;

    private void Awake()        // Handle Singleton
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentWavePool = wavePools[0];     // Start currentWavePool at first wave in list
        SpawnWave();                        // Spawn the first wave
    }

    public void RaiseDifficulty()
    {
        if (((int)currentDifficulty + 1) < wavePools.Count) // Check if we are not at the end of wavePools; otherwise, stay on last WavePool
        {
            currentDifficulty++;                
            currentWavePool = wavePools[((int)currentDifficulty)];
        }
    }

    public void SpawnWave()
    {
        // CHECK IF WAVE SELECTED IS NULL TO PREVENT NULL REF EXC
        GameObject waveParent = GameObject.Find(WAVE_PARENT_NAME);
        // Event for UI
        onWaveStart.Invoke(waveCounter);
        // Spawn wave using RandomWaveSelect()
        GameObject wave = Instantiate(currentWavePool.RandomWaveSelect(), waveParent.transform);

        if (!wave)
        {
            // handle errors with no waves existing in a wavepool
        }
    }

    public void UpdateWaveCounter()         // Update waveCounter and check if we need to raise the difficulty
    {
        waveCounter++;
        // changeWavePoolAfter * i = nextWavePoolChange; Ex: 10 * 2 = 20 next WavePool after Wave 20
        if (waveCounter >= changePoolAfterWaves * waveCountMult)
        {

            RaiseDifficulty();
            waveCountMult++;
        }
    }

    public bool rollVarientMedChance()
    {
        int roll = UnityEngine.Random.Range(0, 101);
        return (roll > (100 - currentWavePool.varientMedChance));
    }

    public bool rollVarientHardChance()
    {
        int roll = UnityEngine.Random.Range(0, 101);
        return (roll > (100 - currentWavePool.varientHardChance));
    }

    public int GetVarientMaxSpawn()
    {
        return currentWavePool.varientMaxSpawn;
    }
}
