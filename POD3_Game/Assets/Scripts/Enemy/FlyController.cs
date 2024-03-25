using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float lineOfSight;
    public float movesped;
    public float attackRange;
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

        lineOfSight = 9f;
        movesped = 7f;
        attackRange = 6f;
        attackSpeed = 3f;

        health = 10f;
        timeAddOnDeath = 10f;
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

    //Show visual ranges in editor of Fly
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}