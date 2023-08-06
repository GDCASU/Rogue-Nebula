using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsUI;

    private void Start()
    {
        // Making sure the pause menu is not accidently set active when we load the scene
        if (pauseUI.activeSelf)
        {
            pauseUI.SetActive(false);
        }
    }

    public void TogglePauseUI()
    {
        if (pauseUI != null)
        {
            if (pauseUI.activeSelf)     // If pause menu is opened then close
            {
                pauseUI.SetActive(false);
                if (optionsUI.activeSelf)       // Disable options menu if pause menu is closed
                    ToggleOptionseUI();
            }
            else                        // If pause menu is closed then open
                pauseUI.SetActive(true);
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
}