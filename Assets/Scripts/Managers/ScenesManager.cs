using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene     // Scenes should be in this order in the Project Settings
{
    MainMenu,
    Main,
    GameOver,
    Options,
    Leaderboard
}

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

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
    }

    public void LoadScene(Scene scene)      // Loads a scene at an index
    {
        //if (SceneManager.GetSceneAt(((int)scene)) != null)
            SceneManager.LoadScene(scene.ToString());
    }

    public void LoadMainMenu()      // Loads the MainMenu Scene
    {
        //if (SceneManager.GetSceneAt(((int)Scene.MainMenu)) != null)
            SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadGameOver()      // Loads the MainMenu Scene
    {
        //if (SceneManager.GetSceneAt(((int)Scene.MainMenu)) != null)
        SceneManager.LoadScene(Scene.GameOver.ToString());
    }

    public void LoadGame()           // Loads the game scene
    {
        //if (SceneManager.GetSceneAt(((int)Scene.Main)) != null)
        SceneManager.LoadScene(Scene.Main.ToString());
    }

    public void LoadNextScene()     // Loads the next scene by the projects buildIndex
    {
        //if (SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1) != null)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        // END THE GAME SOMEHOW
    }
}
