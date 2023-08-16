using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;

    [Header("Padding")]
    [SerializeField] private float templateHeight = 20f;

    // Game Data
    private HighScores _highScores;

    public void OnEnable()
    {
        _highScores = SaveSystem.instance?.highScores;

        if (_highScores == null || entryContainer == null 
            || entryTemplate == null)
            return;

        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            
            HighScoreUI entryUI = entryTransform.GetComponent<HighScoreUI>();

            if (entryUI != null)
            {
                int rank = i + 1;
                string rankString;
                switch (rank)
                {
                    default:
                        rankString = rank + "TH"; break;
                    case 1: rankString = "1ST"; break;
                    case 2: rankString = "2ND"; break;
                    case 3: rankString = "3RD"; break;
                }

                entryUI.rankText.text = rankString;
                entryUI.scoreText.text = _highScores.data[i].score.ToString();
                entryUI.nameText.text = _highScores.data[i].name;
            }
        }
    }
}
