using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TMP_Text textbox;
    
    private int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int amount)
    {
        score += amount;                    // Update score

        textbox.text = score.ToString();    // Show new score
    }
}
