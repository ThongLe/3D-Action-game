using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportObject : MonoBehaviour
{
    public float timerIncrement = 20f; // Adjust this value as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment the special timer of the player
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                playerAttack.special_timer += timerIncrement;
            }

            // Destroy the support object
            Destroy(gameObject);
        }
    }
}
