using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSwapCommand : MonoBehaviour
{
    private bool pickUpAllowed;

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);

        // Set objectPickedUp flag to true for the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetObjectPickedUp(true);
            }
        }
    }
}
