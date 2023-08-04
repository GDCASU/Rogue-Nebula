using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] public GameObject leaderboardUI;

    private void Start()
    {
        // Making sure the leaderboard menu is not accidently set active when we load the scene
        if (leaderboardUI.activeSelf)
        {
            leaderboardUI.SetActive(false);
        }
    }

    public void ToggleLeaderboardUI()
    {
        if (leaderboardUI != null)
        {
            if (leaderboardUI.activeSelf)
                leaderboardUI.SetActive(false);
            else 
                leaderboardUI.SetActive(true);
        }
    }
}
