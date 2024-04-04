using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D bulletRB;

    public float speed;
    public float timeDecreaseOnHit;

    private void Start() {
        speed = 5f;
        timeDecreaseOnHit = 3f;

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        // Move bullet in direction player was on instantiate
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Destroy bullet on collision
        if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("EnemyBullet")) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Call timer decrease function
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerBullet")) {
            Debug.Log($"Player lost {timeDecreaseOnHit} seconds.");
            Destroy(this.gameObject);
        }
    }
}