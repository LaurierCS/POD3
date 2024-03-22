using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float lineOfSight = 13f;
    public float movesped = 7f;
    public float attackRange = 6f;
    public float attackSpeed = 2f;

    public float health = 10f;
    public float timeAddOnDeath = 3f;

    public Transform playerTransform;
    public float nextFireTime;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > attackRange) {
            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, movesped * Time.deltaTime);
        } else if (distanceFromPlayer <= attackRange && nextFireTime < Time.time) {
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
            nextFireTime = Time.time + attackSpeed;
        }
    }

    //When health = 0, call this
    private void OnDeath() {
        /* 
            call func to add time to level, pass timeAddOnDeath
            
         */

        Destroy(this.gameObject);
    }

    //Show ranges
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}