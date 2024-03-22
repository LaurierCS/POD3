using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float speed = 10; // Increased speed for faster movement
    private Vector2 dir;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Calculate direction vector pointing from bullet to "Dir" object
        Vector3 targetPosition = GameObject.Find("Dir").transform.position;
        Vector3 startPosition = GameObject.Find("FirePoint").transform.position;
        dir = new Vector2(targetPosition.x - startPosition.x, 0).normalized;

        // Set initial position to the position of "FirePoint"
        transform.position = startPosition;

        // Get the SpriteRenderer component attached to the bullet GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move the bullet in the calculated direction
        transform.position += (Vector3)dir * speed * Time.deltaTime;

        // Flip the bullet sprite based on the direction
        if (dir.x > 0)
        {
            // Facing right
            spriteRenderer.flipX = false;
        }
        else if (dir.x < 0)
        {
            // Facing left
            spriteRenderer.flipX = true;
        }
    }
}
