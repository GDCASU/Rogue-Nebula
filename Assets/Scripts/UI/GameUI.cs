using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameUI : MonoBehaviour
{
    [Header("UI Popouts")]
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject leaderboardUI;

    [Header("Sounds")]
    [SerializeField] private AudioClip selectionSound;

    private PauseGame pauseGameScript;

    private void Start()
    {
        pauseGameScript = GetComponent<PauseGame>();

        PlayerInput.onPause += TogglePauseUI; 
        // Making sure the pause menu is not accidently set active when we load the scene
        if (pauseUI.activeSelf)
            pauseUI.SetActive(false);
    }

    public void TogglePauseUI()
    {
        if (pauseUI != null)
        {
            if (pauseUI.activeSelf)     // If pause menu is opened then close
            {
                pauseUI.SetActive(false);
                pauseGameScript.TogglePauseGame(false);
                AudioManager.instance.PauseMenuResonance(false);
                if (optionsUI.activeSelf)       // Disable options menu if pause menu is closed
                    ToggleOptionseUI();
                if (leaderboardUI.activeSelf)
                    ToggleLeaderboardUI();
            }
            else                        // If pause menu is closed then open
            {
                pauseUI.SetActive(true);
                pauseGameScript.TogglePauseGame(true);
                AudioManager.instance.PauseMenuResonance(true);
            }
        }
    }

    public void ToggleLeaderboardUI()
    {
        if (leaderboardUI != null)
        {
            if (leaderboardUI.activeSelf)           // If options menu is opened then close
                leaderboardUI.SetActive(false);
            else
                leaderboardUI.SetActive(true);      // If options menu is closed then open
        }
    }

    public void ToggleOptionseUI()
    {
        if (optionsUI != null)
        {
            if (optionsUI.activeSelf)           // If options menu is opened then close
                optionsUI.SetActive(false);
            else
                optionsUI.SetActive(true);      // If options menu is closed then open
        }
    }

    public void PlaySelectionSound()
    {
        if (selectionSound != null)
            AudioManager.instance.PlaySFX(selectionSound);
    }
}
