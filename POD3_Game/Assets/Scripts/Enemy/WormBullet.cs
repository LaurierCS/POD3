using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBullet : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D bulletRB;

    public float speed;
    public float timeDecreaseOnHit;

    private void Start() {
        speed = 3f;
        timeDecreaseOnHit = 5f;

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        Destroy(this.gameObject, 15f);
    }
    
    private void Update() {
        // Move bullet to current position of player (homing)
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Destroy bullet on collision
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Call timer decrease function
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log($"Player lost {timeDecreaseOnHit} seconds.");
            Destroy(this.gameObject);
        }
    }
}