using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    public AudioClip balloonPopSound;
    public TextMeshProUGUI scoreText;
    public GameOverScreen GameOverScreen;
    private ScoreManager scoreManager;
    private AudioSource audioSource;
    private bool isGameOver = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            // Restart the game
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    public void PlayBalloonPopSound()
    {
        audioSource.PlayOneShot(balloonPopSound);
    }

    public void GameOver()
    {
        GameOverScreen.Setup(ScoreManager.score);
    }
}