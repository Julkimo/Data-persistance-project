using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class TextManagerMain : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    private MainManager mainManager;

    private void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        highscoreText.text = "Highscore : " + TextData.GetTopName() + " : " + TextData.GetTopScore();
    }

    public void UpdateHighscore()
    {
        if (mainManager.m_Points >= TextData.GetTopScore())
        {
            TextData.SetTopScore(mainManager.m_Points);
            TextData.SetTopName(TextData.GetPlayerName());
            highscoreText.text = "Highscore : " +  TextData.GetPlayerName() + " : " + TextData.GetTopScore();
        }
    }

    public void BackToMenu()
    {
        SaveData();
        SceneManager.LoadScene(0);
    }

    public void SaveData()
    {
        SaveData data = new SaveData();
        data.name = TextData.GetTopName();
        data.score = TextData.GetTopScore();

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
