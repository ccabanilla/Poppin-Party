using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public ScoreManager scoreManager;

    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }
    }
    public void TimedButton()
    {
        SceneManager.LoadScene("Timed");
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }
    }

    public void EndlessButton()
    {
        SceneManager.LoadScene("Endless");
        if (scoreManager != null)
        {
            scoreManager.SetScore(0);
        }
    }

}
