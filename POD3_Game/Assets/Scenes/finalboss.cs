using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Define the name of the scene you want to transition to
    public string sceneName;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the new scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
