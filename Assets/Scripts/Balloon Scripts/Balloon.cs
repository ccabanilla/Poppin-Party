using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Balloon : MonoBehaviour
{
    [SerializeField] protected Vector3 force;
    [SerializeField] protected Sprite[] balloonSprites;
    public float speed = 2.0f;
    protected Rigidbody2D rb2d;
    protected bool isPopped = false;
    public AudioClip popSound;
    protected Shake shake;
    protected GameController gameController;
    public ScoreManager scoreManager;
    private float frozenTimer = 0f;
    private bool isFrozen = false;
    private Vector2 originalPosition;
    private Vector2 originalVelocity;

    public GameObject particleSystemPrefab;


    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed);
        originalVelocity = rb2d.velocity;
        originalPosition = transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
        gameController = FindObjectOfType<GameController>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        if (gameController == null)
        {
            Debug.LogError("Could not find GameController object.");
        }
    }
    protected virtual void pop()
    {
        scoreManager.IncreaseScore();
    }
    protected virtual void OnMouseDown()
    {
        if (!isPopped)
        {
            isPopped = true;
            pop();
            GameObject particles = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            GetComponent<SpriteRenderer>().sprite = balloonSprites[1];
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(force, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(popSound, transform.position);
            gameController.PlayBalloonPopSound();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Top Wall")
        {
            if (!isPopped)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void ResetBalloon()
    {
        isFrozen = false;
        // Reset position and velocity to their original values
        rb2d.velocity = originalVelocity;
    }

    public void Freeze(float duration)
    {
        isFrozen = true;
        rb2d.velocity = Vector2.zero;
    }

}
