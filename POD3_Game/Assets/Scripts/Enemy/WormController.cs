using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public float lineOfSight;
    public float attackSpeed;

    public float health;
    public float timeAddOnDeath;

    public Transform playerTransform;
    public float nextFireTime;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        lineOfSight = 11f;
        attackSpeed = 5f;

        health = 10f;
        timeAddOnDeath = 3f;
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

        if (health <= 0) {
            StartCoroutine(OnDeath());
        }
    }

    IEnumerator OnDeath() {
        /*
            call func to add time to level, pass timeAddOnDeath
        */

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("PlayerBullet")) {
            //health = health - *value for player bullet damage*
        }
    }

    //Show visual ranges in editor of Worm
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}