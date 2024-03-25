using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBullet : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D bulletRB;

    public float speed = 7f;
    public float damage = 3f;

    private void Start() {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        Destroy(this.gameObject, 5f);
    }
    
    private void Update() {
        // Move bullet to current position of player (homing)
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Destroy bullet on collision
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Teacher")) {
            Destroy(this.gameObject);
        }

        // Call damage player function here
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log($"Hit the player for {damage}");
            Destroy(this.gameObject);
        }
    }
}