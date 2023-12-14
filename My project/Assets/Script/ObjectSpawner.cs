using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // public GameObject[] objectsToSpawn; // Array of object prefabs to randomly choose from
    // public Transform[] spawnPositions; // Array of positions where the object can spawn
    // public float spawnCooldown = 2f; // Cooldown between spawns in seconds
    // public float spawnRadius = 5f; // Radius of the circle for spawning

    // void Start()
    // {
    //     StartCoroutine(SpawnObjectsWithCooldown());
    // }

    // IEnumerator SpawnObjectsWithCooldown()
    // {
    //     while (true) // Infinite loop to keep spawning
    //     {
    //         SpawnObjectRandomly();

    //         yield return new WaitForSeconds(spawnCooldown);
    //     }
    // }

    // void SpawnObjectRandomly()
    // {
    //     if (objectsToSpawn == null || spawnPositions.Length == 0 || objectsToSpawn.Length == 0)
    //     {
    //         Debug.LogError("Object to spawn or spawn positions are not set!");
    //         return;
    //     }

    //     GameObject objectPrefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

    //     // Select a random position from the array
    //     Transform randomSpawnPoint = spawnPositions[Random.Range(0, spawnPositions.Length)];

    //     // Generate random polar coordinates within the circle
    //     float randomRadius = Random.Range(0f, spawnRadius);
    //     float randomAngle = Random.Range(0f, 2f * Mathf.PI);

    //     // Convert polar coordinates to Cartesian coordinates
    //     float spawnX = randomSpawnPoint.position.x + randomRadius * Mathf.Cos(randomAngle);
    //     float spawnZ = randomSpawnPoint.position.z + randomRadius * Mathf.Sin(randomAngle);

    //     Vector3 spawnPos = new Vector3(spawnX, randomSpawnPoint.position.y, spawnZ);

    //     // Instantiate the object at the selected position
    //     Instantiate(objectPrefab, spawnPos, Quaternion.identity);
    // }

    public GameObject[] objectsToSpawn; // Array of object prefabs to randomly choose from
    public Transform[] spawnPositions; // Array of positions where the object can spawn
    public float spawnCooldown = 2f; // Cooldown between spawns in seconds
    public float spawnRadius = 5f; // Radius of the circle for spawning

    private GameObject lastSpawnedObject;
    private Vector3 lastSpawnedPosition;

    void Start()
    {
        StartCoroutine(SpawnObjectsWithCooldown());
    }

    IEnumerator SpawnObjectsWithCooldown()
    {
        while (true) // Infinite loop to keep spawning
        {
            SpawnObjectRandomly();

            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    void SpawnObjectRandomly()
    {
        if (objectsToSpawn == null || spawnPositions.Length == 0 || objectsToSpawn.Length == 0)
        {
            Debug.LogError("Object to spawn or spawn positions are not set!");
            return;
        }

        GameObject objectPrefab;
        Transform randomSpawnPoint;

        // Attempt to find a different object and position than the previous one
        do
        {
            objectPrefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            randomSpawnPoint = spawnPositions[Random.Range(0, spawnPositions.Length)];
        }
        while (objectPrefab == lastSpawnedObject && randomSpawnPoint.position == lastSpawnedPosition);

        // Save the current object and position for the next iteration
        lastSpawnedObject = objectPrefab;
        lastSpawnedPosition = randomSpawnPoint.position;

        // Generate random polar coordinates within the circle
        float randomRadius = Random.Range(0f, spawnRadius);
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        // Convert polar coordinates to Cartesian coordinates
        float spawnX = randomSpawnPoint.position.x + randomRadius * Mathf.Cos(randomAngle);
        float spawnZ = randomSpawnPoint.position.z + randomRadius * Mathf.Sin(randomAngle);

        Vector3 spawnPos = new Vector3(spawnX, randomSpawnPoint.position.y, spawnZ);

        // Instantiate the object at the selected position
        Instantiate(objectPrefab, spawnPos, Quaternion.identity);
    }

}
