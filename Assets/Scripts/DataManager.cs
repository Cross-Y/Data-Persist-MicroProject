using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string bestPlayer;
    public string namePlayer;
    public int maxScore;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class ScoreGame
    {
        public string bestPlayer;
        public int maxScore;
    }

    public void Save()
    {
        ScoreGame data = new ScoreGame();
        data.bestPlayer = bestPlayer;
        data.maxScore = maxScore;

        string json = JsonUtility.ToJson(data); 

        File.WriteAllText(Application.persistentDataPath + "/DataManager.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/DataManager.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreGame data = JsonUtility.FromJson<ScoreGame>(json);

            bestPlayer = data.bestPlayer;
            maxScore = data.maxScore;
        }
    }
}
