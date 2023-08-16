using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    [Header("UI Popouts")]
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject leaderboardUI;
    [SerializeField] private GameObject optionsUI;

    [Header("Sounds")]
    [SerializeField] private AudioClip selectionSound;

    private void Start()
    {
        // Making sure the leaderboard menu is not accidently set active when we load the scene
        if (startUI.activeSelf)
            startUI.SetActive(false);
        if (leaderboardUI.activeSelf)
            leaderboardUI.SetActive(false);
        if (optionsUI.activeSelf)
            optionsUI.SetActive(false);
    }

    public void ToggleStartUI()
    {
        if (leaderboardUI.activeSelf)
            return;
        if (optionsUI.activeSelf)
            return;

        if (startUI != null)
        {
            if (startUI.activeSelf)
            {
                startUI.SetActive(false);
            }
            else
            {
                startUI.SetActive(true);
            }
        }
    }

    public void ToggleLeaderboardUI()
    {
        if (optionsUI.activeSelf)
            return;
        if (startUI.activeSelf)
            return;

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

    public void ToggleOptionsUI()
    {
        if (leaderboardUI.activeSelf)
            return;
        if (startUI.activeSelf)
            return;

        if (optionsUI != null)
        {
            if (optionsUI.activeSelf)       // Close Options
            {
                optionsUI.SetActive(false);
                AudioManager.instance.PauseMenuResonance(false);
            }
            else                            // Open Options
            {
                optionsUI.SetActive(true);
                AudioManager.instance.PauseMenuResonance(true);
            }
        }
    }

    public void GrabNameFromInputField(string name)
    {
        ScoreKeeper.instance.SetName(name);
    }

    public void PlaySelectionSound()
    {
        if (selectionSound != null)
            AudioManager.instance.PlaySFX(selectionSound);
    }

    public void LoadHighScores()
    {
        ScoreKeeper.instance.PrintHighScores();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
