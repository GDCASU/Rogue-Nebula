using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum WaveDifficulty
{
    easy = 0,
    medium = 1,
    hard = 2
}

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [Header("Wave Pools")]
    [SerializeField] private int changePoolAfterWaves = 10;
    [SerializeField] private List<WavePool> wavePools = new List<WavePool>();

    [Header("Difficulty")]
    [SerializeField] public WaveDifficulty currentDifficulty = 0;       // Should not be tampered with; just for testing

    private WavePool currentWavePool = null;
    private int waveCounter = 0;
    private int waveCountMult = 1; // Used to keep track of when to change WavePools 

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
        if (wavePools[((int)currentDifficulty) + 1] != null) // Check if we are not at the end of wavePools; otherwise, stay on last WavePool
        {
            currentDifficulty++;                
            currentWavePool = wavePools[((int)currentDifficulty)];
        }
    }

    public void SpawnWave()
    {
        currentWavePool?.SpawnWave();
    }

    public void UpdateWaveCounter()         // Update waveCounter and check if we need to raise the difficulty
    {
        waveCounter++;
        if (waveCounter >= changePoolAfterWaves)
        {
            RaiseDifficulty();
            waveCountMult++;
            changePoolAfterWaves *= waveCountMult; // changeWavePoolAfter * i = nextWavePoolChange; Ex: 10 * 2 = 20 next WavePool after Wave 20
        }
    }


}
