using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score = 0;


    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    void Start()
    {
        UpdateScoreText();
    }

    public void SetScore(int currentScore)
    {
        score = currentScore;
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        // Here you can add any additional logic related to updating the score, such as displaying it on the screen
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, score);
    }
}
