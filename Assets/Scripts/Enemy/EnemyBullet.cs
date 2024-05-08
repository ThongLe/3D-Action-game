using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damageAmount = 1f;
    public float bulletLifetime = 3f;
    private void Start()
    {
        // Start the countdown to destroy the bullet after its lifetime expires
        StartCoroutine(DestroyAfterLifetime());
    }
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            PlayerStatus playerStatus = hitTransform.GetComponent<PlayerStatus>();
            if (playerStatus != null)
            {
                playerStatus.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("PlayerStatus component not found on the player GameObject.");
            }

            // Destroy the bullet after hitting the player
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject);
    }
}
