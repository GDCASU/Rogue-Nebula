using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool gamePaused = false;

    public void TogglePauseGame()       // Pauses actual game; does not bring up pause menu
    {
        if (!gamePaused)
            PauseGame();
        else
            ResumeGame();
    }

    private void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
    }
}
