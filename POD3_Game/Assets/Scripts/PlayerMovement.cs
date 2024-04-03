using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject bulletPrefab; // Prefab of the bullet object
    public Transform shootPoint; // Point from where the bullet will be instantiated
    public float bulletSpeed = 10f; // Speed of the bullet

    private bool objectPickedUp = false; // Flag to track whether the object is picked up
    private int bulletsFired = 0; // Counter for bullets fired

    Vector2 movement;

    void Update()
    {
        // Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Normalize the input vector to ensure consistent speed in all directions
        movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Update animator parameters
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.magnitude); // Using magnitude instead of sqrMagnitude for speed
        }

        // Shooting
        if (objectPickedUp && Input.GetKeyDown(KeyCode.F) && bulletsFired < 10)
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Movement
        if (rb != null)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Shoot()
    {
        // Ensure bulletPrefab and shootPoint are not null
        if (bulletPrefab != null && shootPoint != null)
        {
            // Instantiate bullet
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Ensure bulletRb is not null
            if (bulletRb != null)
            {
                // Determine shooting direction based on player's orientation
                Vector2 shootingDirection = Vector2.zero;

                if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
                {
                    // Moving horizontally
                    shootingDirection.x = Mathf.Sign(movement.x);
                }
                else
                {
                    // Moving vertically or standing still
                    shootingDirection.y = Mathf.Sign(movement.y);
                }

                // Add force to the bullet to make it move
                bulletRb.velocity = shootingDirection * bulletSpeed;
            }

            // Increment bullets fired count
            bulletsFired++;

            // Destroy the bullet after 5 seconds
            Destroy(bullet, 5f);
        }
    }

    // Function to set objectPickedUp flag and reset bulletsFired count
    public void SetObjectPickedUp(bool pickedUp)
    {
        objectPickedUp = pickedUp;
        bulletsFired = 0; // Reset bulletsFired count
    }
}
