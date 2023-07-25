using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WavePool", menuName = "Waves/Wave Pool")]
public class WavePool : ScriptableObject
{
    [SerializeField] public List<Wave> waves = new List<Wave>();
    [SerializeField] public float varientChance = 0f;

    public void RandomWaveSelect()
    {

    }
}
