using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;
    [SerializeField] private GameObject bigSwarmerPrefab;

    [SerializeField] private int numberOfEnemies = 5; // Number of enemies to spawn at once

    // Game area dimensions
    [SerializeField] private float gameAreaWidth = 10f;
    [SerializeField] private float gameAreaHeight = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMultipleEnemies(numberOfEnemies, swarmerPrefab));
        StartCoroutine(SpawnMultipleEnemies(numberOfEnemies, bigSwarmerPrefab));
    }

    private IEnumerator SpawnMultipleEnemies(int count, GameObject enemyPrefab)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemyPrefab);
            yield return null; // Yield null to wait for the next frame
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        // Calculate a random position within the game area
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the enemy at the calculated position
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Calculate random X and Y coordinates within the game area
        float randomX = Random.Range(-gameAreaWidth / 2f, gameAreaWidth / 2f);
        float randomY = Random.Range(-gameAreaHeight / 2f, gameAreaHeight / 2f);

        // Return the calculated position
        return new Vector3(randomX, randomY, 0f);
    }
}
