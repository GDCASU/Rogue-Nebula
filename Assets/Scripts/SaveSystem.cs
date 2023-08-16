using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using JetBrains.Annotations;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    [SerializeField] private string fileName;

    [Header("Save Data")]
    [SerializeField] public HighScores highScores;

    private string _dataDirPath;
    private string _dataFileName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        FileDataHandler(Application.persistentDataPath, fileName);      // Handle file Path

        LoadGame();
        if (highScores == null)
        {
            highScores = new HighScores();
        }
    }

    public void FileDataHandler(string dataDirPath, string dataFileName)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
    }

    public void LoadGame()
    {
        // use Path.Combine to account for different OS's having different path separators
        string fullPath = _dataDirPath + "/" + _dataFileName;

        HighScores loadData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(fullPath, FileMode.Open);

                loadData = new HighScores();

                for (int i = 0; i < stream.Length; i++)
                {
                    loadData.data[i].name = formatter.Deserialize(stream) as string;
                    int[] score = formatter.Deserialize(stream) as int[];
                    loadData.data[i].score = score[0];
                }
                stream.Close();
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data to file: " + fullPath + "\n" + e);
            }
        }

        highScores = loadData;
    }

    public void SaveGame()
    {
        string fullPath = _dataDirPath + "/" + _dataFileName;
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fullPath, FileMode.Create);

            foreach (HighScore highScore in highScores.data)
            {
                formatter.Serialize(stream, highScore.name);

                int[] score = { highScore.score };
                formatter.Serialize(stream, score);
            }
            stream.Close();
        }
        catch (Exception e) 
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    private void OnApplicationQuit()
    {
        // SAVE THE GAME
        SaveGame();
    }
}
