using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisController : MonoBehaviour
{
    public float lineOfSight;
    public float movesped;
    public float attackRange;
    public float attackSpeed;

    public float health;
    public float timeAddOnDeath;

    public Transform playerTransform;
    public float nextAttackTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        lineOfSight = 6f;
        movesped = 5f;
        attackRange = 2f;
        attackSpeed = 3f;
        
        health = 10f;
        timeAddOnDeath = 10f;
    }

    void Update()
    {
        // Get Mantis' distance from player
        float distanceFromPlayer = Vector2.Distance(playerTransform.position, transform.position);

        // Move and attack logic
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > attackRange) {
            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, movesped * Time.deltaTime);
        } else if (distanceFromPlayer <= attackRange && nextAttackTime < Time.time) {
            //Attack stuff here
            nextAttackTime = Time.time + attackSpeed;
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

    //Show visual ranges in editor of Mantis
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
