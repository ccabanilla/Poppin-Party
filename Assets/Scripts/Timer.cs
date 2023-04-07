using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TextMeshProUGUI timerText;
    public GameController gameController;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        int seconds = Mathf.RoundToInt(timeLeft);
        timerText.text = "Time: " + seconds;

        if (timeLeft <= 0.0f)
        {
            gameController.GameOver();
            enabled = false;
        }
    }
}
