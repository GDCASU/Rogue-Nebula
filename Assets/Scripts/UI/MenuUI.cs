using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] public GameObject leaderboardUI;
    [SerializeField] public GameObject optionsUI;

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
                leaderboardUI.SetActive(false);
            else 
                leaderboardUI.SetActive(true);
        }
    }
    public void ToggleOptionsUI()
    {
        if (leaderboardUI.activeSelf)
            return;

        if (optionsUI != null)
        {
            if (optionsUI.activeSelf)
                optionsUI.SetActive(false);
            else
                optionsUI.SetActive(true);
        }
    }
}
