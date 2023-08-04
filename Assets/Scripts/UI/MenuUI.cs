using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] public GameObject leaderboardUI;

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
