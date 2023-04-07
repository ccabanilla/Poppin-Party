using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public List<GameObject> cloudPrefabs;
    public float spawnRate = 1.0f;
    private float spawnTimer = 0.0f;
    public float minSpawnY = -4.52f;
    public float maxSpawnY = 3.1f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 2.0f;
    public bool spawnLeft = true;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;

            // Randomly choose a cloud prefab
            int index = Random.Range(0, cloudPrefabs.Count);
            GameObject cloudPrefab = cloudPrefabs[index];

            // Set the spawn position and speed based on spawn direction
            Vector3 spawnPosition = transform.position;
            float speed = Random.Range(minSpeed, maxSpeed);
            if (spawnLeft)
            {
                spawnPosition.x = -10.0f;
                spawnPosition.y = Random.Range(minSpawnY, maxSpawnY);
            }
            else
            {
                spawnPosition.x = 10.0f;
                spawnPosition.y = Random.Range(minSpawnY, maxSpawnY);
                speed = -speed;
            }

            // Spawn the cloud and set its speed
            GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            CloudMovement cloudMovement = newCloud.AddComponent<CloudMovement>();
            cloudMovement.speed = speed;
            cloudMovement.moveLeft = spawnLeft;
        }
    }
}

public class CloudMovement : MonoBehaviour
{
    public float speed;
    public bool moveLeft;

    void Update()
    {
        // Move the cloud left or right based on its direction and speed
        float xMovement = moveLeft ? -speed : speed;
        transform.position += new Vector3(xMovement * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left Wall")
        {
                Destroy(this.gameObject);
        }
    }
}
