using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class LeaderboardUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;

    [Header("Padding")]
    [SerializeField] private float templateHeight = 20f;

    // High Score Data Container
    private HighScores _highScores;

    public void OnEnable()
    {
        _highScores = ScoreKeeper.instance?.highScores;

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

                string playerName = _highScores.data[i].name;
                playerName = OmitHashFromString(playerName);
                entryUI.nameText.text = playerName;
            }
        }
    }

    // Unity puts a random 4 digit number like #1234 on the back of each player's name, this cuts it out of the submission
    private string OmitHashFromString(string name)
    {
        if (name == null)
            return name;

        int indexOfHash = name.IndexOf('#');
        if (indexOfHash != -1)
            return name.Substring(0, indexOfHash);
        else
            return name;
    }
}
