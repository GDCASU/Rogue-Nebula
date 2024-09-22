using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using Unity.Services.Authentication;

public class ScoreKeeper : MonoBehaviour
{
    private const string LEADERBOARD_ID = "Rogue_Nebula_Leaderboard";

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

        if (highScores == null)
            highScores = ScriptableObject.CreateInstance<HighScores>();     // New Highscore dataContainer if none exists

        ResetScore();
    }

    private async void Start()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        UpdateHighScoreDataFromNetwork();   // Get the highest scores from the network at the start of the game
    }

    public void SetName(string name)
    {
        if (name != string.Empty)     // If the user does not enter anything then keep the name as "Anonymous"
        {
            _name = name;
        }

        Debug.Log(_name);
        // Update the user on the Ryan
        AuthenticationService.Instance.UpdatePlayerNameAsync(_name);
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
        // Adds the player score to the network
        AddHighScoreToNetwork(_name, _score);
        //UpdateHighScoreData();
    }

    // Update Scriptable Object 
    private void UpdateHighScoreData()
    {
        if (this.highScores == null)
            return;

        // Adds the player score to the leaderboard (if applicable)
        HighScore possibleHighScore;
        possibleHighScore.name = _name;
        possibleHighScore.score = _score;

        HighScore[] highscores = highScores.data;
        HighScore temp1 = possibleHighScore;
        HighScore temp2;
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

    #region Networked Score
    public async void UpdateHighScoreDataFromNetwork()
    {
        if (Application.isPlaying)
        {
            // Aquire the page 
            LeaderboardScoresPage page = await LeaderboardsService.Instance.GetScoresAsync(LEADERBOARD_ID);

            int index = 0;
            HighScore[] highscores = highScores.data;
            foreach (LeaderboardEntry entry in page.Results)    // Loop to insert the newest high score
            {
                if (index >= 10)
                    return;

                HighScore scoreToAdd;
                scoreToAdd.score = page.Offset;

                highscores[index].score = (int)entry.Score;
                highscores[index].name = entry.PlayerName;
                index++;
            }
        }
    }

    public void AddHighScoreToNetwork(string name, int score)
    {
        double doubledScore = (double)score;
        LeaderboardsService.Instance.AddPlayerScoreAsync(LEADERBOARD_ID, score);
        UpdateHighScoreDataFromNetwork();
    }
    #endregion

    public void PrintHighScores()
    {
        foreach (HighScore score in highScores.data)
        {
            Debug.Log(score.name + " " +  score.score);
        }
    }
}
