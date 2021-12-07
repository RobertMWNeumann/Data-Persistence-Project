using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string PlayerName;
    public int Score;
    private string savefilePath;
    private readonly string savefileName = "highscore.json";

    [System.Serializable]
    public class BestScore
    {
        public string playerName;
        public int score;
    }

    public BestScore bestScore;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        GameManager.Instance = this;
        DontDestroyOnLoad(this);

        savefilePath = Application.persistentDataPath + "/";
        LoadBestScore();
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadBestScore()
    {
        string savefile = savefilePath + savefileName;

        if (!File.Exists(savefile))
        {
            bestScore.playerName = null;
            bestScore.score = 0;
        }
        else
        {
            string json = File.ReadAllText(savefile);
            BestScore data = JsonUtility.FromJson<BestScore>(json);

            bestScore.playerName = data.playerName;
            bestScore.score = data.score;
        }
    }

    public void SaveBestScore()
    {
        if (Score > bestScore.score)
        {
            string savefile = savefilePath + savefileName;

            BestScore data = new BestScore();
            data.playerName = PlayerName;
            bestScore.playerName = PlayerName;
            data.score = Score;
            bestScore.score = Score;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(savefile, json);
        }
    }
}
