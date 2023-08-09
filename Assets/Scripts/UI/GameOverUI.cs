using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TMP_Text highScoreText;

    [Header("UI Popouts")]
    [SerializeField] private GameObject leaderboardUI;

    [Header("Sounds")]
    [SerializeField] private AudioClip selectionSound;

    private void Start()
    {
        // Making sure the leaderboard menu is not accidently set active when we load the scene
        if (leaderboardUI.activeSelf)
            leaderboardUI.SetActive(false);

        highScoreText.text = ScoreKeeper.instance.GetScore().ToString();
    }

    public void ToggleLeaderboardUI()
    {
        if (leaderboardUI != null)
        {
            if (leaderboardUI.activeSelf)
            {
                leaderboardUI.SetActive(false);
                AudioManager.instance.PauseMenuResonance(false);
            }
            else
            {
                leaderboardUI.SetActive(true);
                AudioManager.instance.PauseMenuResonance(true);
            }
        }
    }

    public void PlaySelectionSound()
    {
        if (selectionSound != null)
            AudioManager.instance.PlaySFX(selectionSound);
    }
}
