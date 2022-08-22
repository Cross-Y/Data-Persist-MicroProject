using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;
    public TextMeshProUGUI bestScore;

    private void Start() 
    {
        DataManager.Instance.Load();

        if(DataManager.Instance.bestPlayer == null)
        {
            DataManager.Instance.bestPlayer = "None";
        }

        ScoreUpdate(DataManager.Instance.bestPlayer, DataManager.Instance.maxScore);    
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void NameUpdate()
    {
        DataManager.Instance.namePlayer = playerName.text;
    }

    public void ScoreUpdate(string name, int score)
    {
        bestScore.text = "Best Score: " + name + " : " + score;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

}
