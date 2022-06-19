using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextData : MonoBehaviour
{
    public static TextData instance;

    public static string playerName = "no one";

    public static string highscoreName = "no one";
    public static int highscoreScore = 0;

    public TextData(string highscoreName, int highscoreScore)
    {
        SetTopName(highscoreName);
        SetTopScore(highscoreScore);
        playerName = null;
    }
    public TextData() {}


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static string GetPlayerName() => playerName;
    public static string GetTopName() => highscoreName;
    public static int GetTopScore() => highscoreScore;

    public static void SetPlayerName(string name) => playerName = name;
    public static void SetTopName(string name) => highscoreName = name;
    public static void SetTopScore(int score) => highscoreScore = score;
}
