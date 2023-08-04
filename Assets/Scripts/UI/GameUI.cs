using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameUI : MonoBehaviour
{
    [SerializeField] public GameObject pauseUI;

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
