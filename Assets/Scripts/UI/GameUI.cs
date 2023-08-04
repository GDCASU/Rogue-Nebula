using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameUI : MonoBehaviour
{
    [SerializeField] public GameObject pauseUI;

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
            if (pauseUI.activeSelf)
                pauseUI.SetActive(false);
            else
                pauseUI.SetActive(true);
        }
    }
}
