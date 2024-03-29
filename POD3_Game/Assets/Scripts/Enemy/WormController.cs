using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public float lineOfSight;
    public float attackSpeed;

    public float timeIncreaseOnDeath;

    public Transform playerTransform;
    public float nextFireTime;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        lineOfSight = 15f;
        attackSpeed = 3f;

        timeIncreaseOnDeath = 10f;
    }

    void Update()
    {
        // Get Worm's distance from player
        float distanceFromPlayer = Vector2.Distance(playerTransform.position, transform.position);
        
        // Attack logic
        if (distanceFromPlayer <= lineOfSight && nextFireTime < Time.time) {
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
            nextFireTime = Time.time + attackSpeed;
        }
    }

    // Call timer decrease function
    IEnumerator OnDeath() {
        Debug.Log($"Player gained {timeIncreaseOnDeath} seconds.");
        
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    // Kill on collision with bullet
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("PlayerBullet")) {
            StartCoroutine(OnDeath());
        }
    }

    //Show visual ranges in editor of Worm
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}