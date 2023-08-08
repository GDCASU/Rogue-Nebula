using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool gamePaused = false;

    public void TogglePauseGame()       // Pauses actual game; does not bring up pause menu
    {
        if (!gamePaused)
            Pause();
        else
            Resume();
    }

    private void Pause()
    {
        gamePaused = true;
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
    }
}
