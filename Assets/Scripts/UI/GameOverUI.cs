using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardUI;

    private void Start()
    {
        // Making sure the leaderboard menu is not accidently set active when we load the scene
        if (leaderboardUI.activeSelf)
            leaderboardUI.SetActive(false);
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
}
