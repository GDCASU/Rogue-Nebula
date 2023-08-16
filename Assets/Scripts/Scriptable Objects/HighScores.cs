using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public struct HighScore
{
    public string name;
    public int score;
}

[CreateAssetMenu(fileName = "HighScores", menuName = "High Scores")]
public class HighScores : ScriptableObject
{
    [SerializeField] public HighScore[] data = new HighScore[10];
}
