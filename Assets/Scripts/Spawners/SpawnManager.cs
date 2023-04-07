using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<SpawnBalloons> spawners;
    public static SpawnManager Instance { get; private set; }

    private void Awake()
    {
        // Make sure there is only one instance of SpawnManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        spawners = new List<SpawnBalloons>(FindObjectsOfType<SpawnBalloons>());
    }

    public void SetBalloonPrefab(string prefabName)
    {
        foreach (SpawnBalloons spawner in spawners)
        {
            spawner.SetCurrentBalloonPrefab(prefabName);
        }
    }
    public void StopSpawning()
    {
        foreach (SpawnBalloons spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public void ResumeSpawning()
    {
        foreach (SpawnBalloons spawner in spawners)
        {
            spawner.ResumeSpawning();
        }
    }
}
