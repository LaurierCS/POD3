using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour
{
    public GameObject visualAlert;
    public bool playerInRange;

    private void Awake() {
        visualAlert.SetActive(false);
        playerInRange = false;
    }

    private void Update() {
        // Visual alert for player in range of teacher
        if (playerInRange) {
            visualAlert.SetActive(true);
        } else {
            visualAlert.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerInRange = false;
        }
    }
}