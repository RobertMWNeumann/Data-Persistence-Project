using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreManager : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        UpdateBestScoreText();
    }

    public void UpdateBestScoreText()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.bestScore.playerName != null)
            {
                string bestScore = "Best Score: " + GameManager.Instance.bestScore.playerName + ": " + GameManager.Instance.bestScore.score;
                bestScoreText.text = bestScore;
            }
        }
    }
}
