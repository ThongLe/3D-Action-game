using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : MonoBehaviour
{
    public float healAmount = 2f; // Amount of health to restore to the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Restore player's health
            PlayerStatus.Instance.Heal(healAmount);

            // Destroy the healing cube
            Destroy(gameObject);
        }
    }
}
