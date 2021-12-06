using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string PlayerName;
    public int Score;

    public string test = "GameManager is persistence";

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
