using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D bulletRB;

    public float speed = 10f;
    public float damage = 2f;

    private void Start() {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Teacher")) {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player")) {
            Debug.Log($"Hit the player for {damage}");
            Destroy(this.gameObject);
        }
    }
}