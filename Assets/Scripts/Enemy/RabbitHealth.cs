using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHealth : MonoBehaviour
{
    public float MaxHealth = 20f;
    public float CurrentHealth;

    public GameObject playerState;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = MaxHealth;
        
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0) {
            Destroy(this.gameObject);
            playerState.GetComponent<PlayerStatus>().ScoreUp();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //effect when hit
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
        //Destroy(this.gameObject);
    }
}
