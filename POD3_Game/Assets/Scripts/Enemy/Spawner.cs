using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject player;

    public GameObject enemyFly;
    public float enemyFlySpawnRate;
    public float nextEnemyFlySpawnTime;
    public float enemyFlySpawnDistance;

    public GameObject enemyWorm;
    public float enemyWormSpawnRate;
    public float nextEnemyWormSpawnTime;
    public float enemyWormSpawnDistance;

    public GameObject enemyMantis;
    public float enemyMantisSpawnRate;
    public float nextEnemyMantisSpawnTime;
    public float enemyMantisSpawnDistance;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        // Fly vars
        enemyFlySpawnRate = 5f;
        enemyFlySpawnDistance = 11f;
        
        // Worm vars
        enemyWormSpawnRate = 10f;
        enemyWormSpawnDistance = 13f;
        
        // Mantis vars
        enemyMantisSpawnRate = 7f;
        enemyMantisSpawnDistance = 9f;
    }

    void Update()
    {
        // Move spawner to player position
        transform.position = player.transform.position;

        // Spawn Fly logic
        if (nextEnemyFlySpawnTime < Time.time) {
            Instantiate(enemyFly, Random.insideUnitCircle.normalized * enemyFlySpawnDistance, Quaternion.identity);
            nextEnemyFlySpawnTime = Time.time + enemyFlySpawnRate;
        }
        
        // Spawn Worm logic
        if (nextEnemyWormSpawnTime < Time.time) {
            Instantiate(enemyWorm, Random.insideUnitCircle.normalized * enemyWormSpawnDistance, Quaternion.identity);
            nextEnemyWormSpawnTime = Time.time + enemyWormSpawnRate;
        }

        // Spawn Fly logic
        if (nextEnemyMantisSpawnTime < Time.time) {
            Instantiate(enemyMantis, Random.insideUnitCircle.normalized * enemyMantisSpawnDistance, Quaternion.identity);
            nextEnemyMantisSpawnTime = Time.time + enemyMantisSpawnRate;
        }
    }

    //Show visual ranges in editor of Spawn Ranges
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyFlySpawnDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyWormSpawnDistance);

        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyMantisSpawnDistance);
    }
}
