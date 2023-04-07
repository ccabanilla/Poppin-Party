using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public ScoreManager scoreManager;

    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void TRestartButton()
    {
        SceneManager.LoadScene("Timed");
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }

    }

    public void ERestartButton()
    {
        SceneManager.LoadScene("Endless");
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }
    }

    public void TLeaderboardButton()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void ELeaderboardButton()
    {
        SceneManager.LoadScene("LeaderBoard 1");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("Shop");
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }
    }
}
