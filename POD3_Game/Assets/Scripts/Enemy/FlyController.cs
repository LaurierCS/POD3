using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float lineOfSight;
    public float movesped;
    public float attackRange;
    public float attackSpeed;
    public Timer timer;

    public float timeIncreaseOnDeath;

    public Transform playerTransform;
    public float nextFireTime;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        lineOfSight = 10f;
        movesped = 3f;
        attackRange = 7f;
        attackSpeed = 5f;

        timeIncreaseOnDeath = 10f;
    }

    void Update()
    {
        // Get Fly's distance from player
        float distanceFromPlayer = Vector2.Distance(playerTransform.position, transform.position);

        // Move and attack logic
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > attackRange) {
            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, movesped * Time.deltaTime);
        } else if (distanceFromPlayer <= attackRange && nextFireTime < Time.time) {
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
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PlayerBullet")) {
            StartCoroutine(OnDeath());
        }
    }

    //Show visual ranges in editor of Fly
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}