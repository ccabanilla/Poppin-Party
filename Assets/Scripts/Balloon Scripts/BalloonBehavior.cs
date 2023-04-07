using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    public float pitchShiftSpeed = 1.0f;
    public bool pitchShift = false;
    public GameController gameController;

    private float originalPitch;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalPitch = audioSource.pitch;
    }

    void Update()
    {
        if (pitchShift)
        {
            audioSource.pitch = originalPitch + Mathf.Sin(Time.time * pitchShiftSpeed) * 0.1f;
        }
    }

    protected virtual void OnMouseDown()
    {
        if (gameObject.CompareTag("Balloon"))
        {
            // Play the balloon pop sound
            gameController.PlayBalloonPopSound();

            // Destroy the balloon
            Destroy(gameObject);
        }
    }
}