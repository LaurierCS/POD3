using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private int numberOfEnemies = 5; // Number of enemies to spawn at once

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMultipleEnemies(numberOfEnemies, swarmerPrefab));
        StartCoroutine(SpawnMultipleEnemies(numberOfEnemies, bigSwarmerPrefab));
    }

    private IEnumerator SpawnMultipleEnemies(int count, GameObject enemy)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemy);
            yield return null; // Yield null to wait for the next frame
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0f), Quaternion.identity);
    }
}
