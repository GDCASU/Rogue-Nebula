using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;

    // Event
    public Action<int> onScoreUpdated;      // Unity event for Score Text UI

    [Header("Data Container")]
    [SerializeField] public HighScores highScores;      // Scriptable Object that holds all highscores of the session

    // Player Info
    [SerializeField] private string _name = "Anonymous";
    [SerializeField] private int _score = 0;

    private void Awake()        // Handle Singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()        // Handle HighScores null ref error
    {
        ResetScore();

        if (highScores == null)
            highScores = ScriptableObject.CreateInstance<HighScores>();     // New Highscore dataContainer if none exists
    }

    public void SetName(string name)
    {
        if (name == "")     // If the user does not enter anything then keep the name as "Anonymous"
            return;

        _name = name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddScore(int amount)
    {
        _score += amount;                    // Update score

        onScoreUpdated?.Invoke(_score);         // Update UI
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void AddHighScore()          // Potentially add a new high score if it beats one of the ten highest scores
    {
        if (this.highScores == null)
            return;

        HighScore possibleHighScore;
        possibleHighScore.name = _name;
        possibleHighScore.score = _score;

        HighScore[] highscores = highScores.data;
        HighScore temp1 = possibleHighScore, temp2;
        for (int i = 0; i < highscores.Length; i++)     // Loop to insert the newest high score
        {
            if (temp1.score > highscores[i].score)          // whatever score ends up in temp1 is thrown away at end
            {
                temp2 = highscores[i];
                highscores[i] = temp1;
                temp1 = temp2;
            }
        }
    }

    public void PrintHighScores()
    {
        foreach (HighScore score in highScores.data)
        {
            Debug.Log(score.name + " " +  score.score);
        }
    }
}
