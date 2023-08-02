using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    // [SerializeField] TMP_Text textbox;       UNUSED
    public UnityEvent<int> onScoreUpdated;      // Unity event for Score Text UI

    private int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int amount)
    {
        score += amount;                    // Update score

        onScoreUpdated?.Invoke(score);         // Update UI
        //textbox.text = score.ToString();   UNUSED // Show new score
    }
}
