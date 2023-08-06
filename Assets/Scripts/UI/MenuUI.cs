using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardUI;
    [SerializeField] private GameObject optionsUI;

    private void Start()
    {
        // Making sure the leaderboard menu is not accidently set active when we load the scene
        if (leaderboardUI.activeSelf)
            leaderboardUI.SetActive(false);
        if (optionsUI.activeSelf)
            optionsUI.SetActive(false);
    }

    public void ToggleLeaderboardUI()
    {
        if (optionsUI.activeSelf)
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
}
