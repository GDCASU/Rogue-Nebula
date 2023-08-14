using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void TogglePauseGame(bool toggle)       // Pauses actual game; does not bring up pause menu
    {
        if (toggle)
            Pause();
        else
            Resume();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
    }
}
