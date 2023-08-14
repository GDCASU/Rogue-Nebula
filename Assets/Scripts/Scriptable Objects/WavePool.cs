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
    [SerializeField] public int varientMedChance = 0;     // Default if chances not hit will just be the base enemy (easy)
    [SerializeField] public int varientHardChance = 0;
    [SerializeField] public int varientMaxSpawn = 0;

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
