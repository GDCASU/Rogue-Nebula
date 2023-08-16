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
    [SerializeField] private GameObject controlsUI;

    [Header("Settings")]
    [SerializeField] private int maxCharactersForInput = 10;

    [Header("Sounds")]
    [SerializeField] private AudioClip selectionSound;

    private void Start()
    {
        startUI.SetActive(false);
        leaderboardUI.SetActive(false);
        optionsUI.SetActive(false);
        controlsUI.SetActive(false);
    }

    public void ToggleStartUI()
    {
        if (leaderboardUI.activeSelf)
            return;
        if (optionsUI.activeSelf)
            return;
        if (controlsUI.activeSelf)
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
        if (controlsUI.activeSelf)
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
        if (controlsUI.activeSelf)
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

    public void ToggleControlsUI()
    {
        if (leaderboardUI.activeSelf)
            return;
        if (startUI.activeSelf)
            return;
        if (optionsUI.activeSelf)
            return;

        if (controlsUI != null)
        {
            if (controlsUI.activeSelf)       // Close Options
            {
                controlsUI.SetActive(false);
                AudioManager.instance.PauseMenuResonance(false);
            }
            else                            // Open Options
            {
                controlsUI.SetActive(true);
                AudioManager.instance.PauseMenuResonance(true);
            }
        }
    }

    public void GrabNameFromInputField(string name)
    {
        if (name.Length > maxCharactersForInput)
            name = name.Substring(0, maxCharactersForInput);

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
