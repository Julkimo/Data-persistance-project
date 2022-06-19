using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TextManager : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    [SerializeField] InputField inputField;

    public void StartGame()
    {
        TextData.SetPlayerName(inputField.text);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
    public void SaveData()
    {
        SaveData data = new SaveData();
        data.name = TextData.GetTopName();
        data.score = TextData.GetTopScore();

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void Awake()
    {
        LoadData();
        highscoreText.text = "Highscore: " + TextData.GetTopName() + " : " + TextData.GetTopScore();
    }

    private void LoadData()
    {
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                TextData.SetTopName(data.name);
                TextData.SetTopScore(data.score);
            }
        }
    }
}
