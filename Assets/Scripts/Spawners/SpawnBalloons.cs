using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloons : MonoBehaviour
{
    public List<GameObject> basicBalloonPrefab;
    public List<GameObject> heartBalloonPrefab;
    public List<GameObject> bearBalloonPrefab;
    public List<GameObject> bubbleBalloonPrefab;
    public List<GameObject> starBalloonPrefab;

    private List<GameObject> currentBalloonPrefab;

    public float spawnRate = 1.0f;
    private float spawnTimer = 0.0f;
    private Vector3 initialPosition;
    private bool isSpawning = true;

    void Start()
    {
            initialPosition = transform.position;

            switch (GameManager.prefabName)
            {
                case "Basic":
                    SetCurrentBalloonPrefab("Basic");
                    break;
                case "Heart":
                    SetCurrentBalloonPrefab("Heart");
                    break;
                case "Bear":
                    SetCurrentBalloonPrefab("Bear");
                    break;
                case "Bubble":
                    SetCurrentBalloonPrefab("Bubble");
                    break;
                case "Star":
                    SetCurrentBalloonPrefab("Star");
                    break;
                default:
                    SetCurrentBalloonPrefab("Basic");
                    break;
            }
    }
    void Update()
    {
        if (!isSpawning) return;

        spawnTimer += Time.deltaTime;
    
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;

            Vector3 spawnPosition = initialPosition;
            spawnPosition.x += Random.Range(-7.69f, 8.08f);
            spawnPosition.y += Random.Range(-6.45f, -6.74f);

            // Instantiate currentBalloonPrefab if it's not null
            if (currentBalloonPrefab != null && currentBalloonPrefab.Count > 0)
            {
                int index = Random.Range(0, currentBalloonPrefab.Count);
                GameObject balloonPrefab = currentBalloonPrefab[index];
                Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                // Instantiate a random balloon from balloonPrefabs if currentBalloonPrefab is null or empty
                GameObject balloonPrefab = currentBalloonPrefab[Random.Range(0, currentBalloonPrefab.Count)];
                Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    public void SetCurrentBalloonPrefab(string prefabName)
    {
        Debug.Log("SetCurrentBalloonPrefab called with prefabName: " + prefabName);
        switch (prefabName)
        {
            case "Basic":
                currentBalloonPrefab = basicBalloonPrefab;
                GameManager.prefabName = "Basic";
                break;
            case "Heart":
                currentBalloonPrefab = heartBalloonPrefab;
                GameManager.prefabName = "Heart";
                break;
            case "Bear":
                currentBalloonPrefab = bearBalloonPrefab;
                GameManager.prefabName = "Bear";
                break;
            case "Bubble":
                currentBalloonPrefab = bubbleBalloonPrefab;
                GameManager.prefabName = "Bubble";
                break;
            case "Star":
                currentBalloonPrefab = starBalloonPrefab;
                GameManager.prefabName = "Star";
                break;
            default:
                Debug.LogWarning("Invalid balloon prefab name: " + prefabName);
                break;
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void ResumeSpawning()
    {
        isSpawning = true;
    }

}
