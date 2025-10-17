using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Drag your Asteroid prefab here
    public float spawnRate = 2f;      // How often to spawn a new asteroid
    public float spawnRangeX = 10f;
    public float spawnRangeZ = 10f;
    public float spawnHeight = 20f;

    void Start()
    {
        // Call the SpawnAsteroid function every 'spawnRate' seconds
        InvokeRepeating("SpawnAsteroid", 2f, spawnRate);
    }

    void SpawnAsteroid()
    {
        // Define a random position
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            spawnHeight,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );

        // Create the asteroid
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}