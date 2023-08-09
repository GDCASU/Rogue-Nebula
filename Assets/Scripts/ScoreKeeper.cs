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
    [SerializeField] private HighScores _highscores;      // Scriptable Object that holds all highscores of the session

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
            Destroy(gameObject);
    }

    private void Start()        // Handle HighScores null ref error
    {
        ResetScore();

        if (_highscores == null)
            _highscores = new HighScores();
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
        if (this._highscores == null)
            return;

        HighScore possibleHighScore;
        possibleHighScore.name = _name;
        possibleHighScore.score = _score;

        HighScore[] highscores = _highscores.highScores;
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
        foreach (HighScore score in _highscores.highScores)
        {
            Debug.Log(score.name + " " +  score.score);
        }
    }
}
