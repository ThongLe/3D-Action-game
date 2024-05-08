using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get; set; }

    public float currentHealth;
    public float maxHealth = 10f;

    private SoundManager soundManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        soundManager = SoundManager.Instance;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        soundManager.PlaySound(soundManager.hurt);
        if (currentHealth <= 0)
        {
            
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health doesn't exceed maxHealth

        // Play heal sound
        soundManager.PlaySound(soundManager.healing);
    }
    void Update()
    {
        
    }
}
