using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public enum Scenes     // Scenes should be in this order in the Project Settings
{
    MainMenu,
    Main,
    GameOver
}

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    [SerializeField] public Scenes currentScene;

    private void Awake()            // Handle Singleton
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()        // Don't Destroy object on loading a new scene
    {
        instance.enabled = true;
        AudioManager.instance.PauseMenuResonance(false);
        playSceneMusic();

        HandlePlayerControls();
    }

    private void HandlePlayerControls()
    {
        switch (currentScene)
        {
            case Scenes.MainMenu:
                PlayerInput.instance.ToggleControls(false); break;
            case Scenes.GameOver:
                PlayerInput.instance.ToggleControls(false); break;
            case Scenes.Main:
                PlayerInput.instance.ToggleControls(true); break;
            default:
                PlayerInput.instance.ToggleControls(true); break;
        }
    }

    public void LoadMainMenu()      // Loads the MainMenu Scene
    {
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
        currentScene = Scenes.MainMenu;
        HandlePlayerControls();
        //ScoreKeeper.instance.PrintHighScores();         // FOR DEBUGGING
        playSceneMusic();
    }

    public void LoadGame()           // Loads the game scene
    {
        SceneManager.LoadScene(Scenes.Main.ToString());
        currentScene = Scenes.Main;
        HandlePlayerControls();
        ScoreKeeper.instance?.ResetScore();         // Reset the current score to 0
        playSceneMusic();
    }

    public void LoadGameOver()      // Loads the MainMenu Scene
    {
        SceneManager.LoadScene(Scenes.GameOver.ToString());
        currentScene = Scenes.GameOver;
        HandlePlayerControls();
        ScoreKeeper.instance?.AddHighScore();       // Add the highscore to the highscore's array if applicable
        playSceneMusic();
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void playSceneMusic()
    {
        AudioManager.instance.StopMusicTrack();     // Stop the current music track b4 starting the next

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (AudioManager.instance != null)      // Check if an AudioManager exists
        {
            switch (buildIndex)
            {
                case 0:
                    AudioManager.instance.PlayMusic(Music.Menu);        // Play menu music
                    break;
                case 1:
                    AudioManager.instance.PlayMusic(Music.Game);        // Play menu music
                    break;
                case 2:
                    AudioManager.instance.PlayMusic(Music.GameOver);        // Play menu music
                    break;
            }
        }
    }
}
