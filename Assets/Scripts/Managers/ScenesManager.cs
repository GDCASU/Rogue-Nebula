using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes     // Scenes should be in this order in the Project Settings
{
    MainMenu,
    Main,
    GameOver
}

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    private Scenes currentScene;

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
        playSceneMusic();
    }

    public void LoadMainMenu()      // Loads the MainMenu Scene
    {
        //if (SceneManager.GetSceneAt(((int)Scene.MainMenu)) != null)
            SceneManager.LoadScene(Scenes.MainMenu.ToString());
        playSceneMusic();
    }

    public void LoadGame()           // Loads the game scene
    {
        //if (SceneManager.GetSceneAt(((int)Scene.Main)) != null)
        SceneManager.LoadScene(Scenes.Main.ToString());
        playSceneMusic();
    }

    public void LoadGameOver()      // Loads the MainMenu Scene
    {
        //if (SceneManager.GetSceneAt(((int)Scene.MainMenu)) != null)
        SceneManager.LoadScene(Scenes.GameOver.ToString());
        playSceneMusic();
    }

    public void LoadNextScene()     // Loads the next scene by the projects buildIndex
    {
        //if (SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1) != null)
        SceneManager.LoadScene(GetActiveSceneIndex() + 1);
        playSceneMusic();
    }

    public void EndGame()
    {
        Application.Quit();
    }

    private int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
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
