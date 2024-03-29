using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestPlayer : MonoBehaviour
{
    public Rigidbody2D playerRB;
    Vector2 movement;
    public float runSpeed = 5f;

    private void Start ()
    {
        playerRB = GetComponent<Rigidbody2D>(); 
    }

    private void Update ()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
        playerRB.MovePosition(playerRB.position + movement * runSpeed * Time.fixedDeltaTime);
    }
}
