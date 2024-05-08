using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get; set; }

    public GameObject player;

    public float currentHealth;
    public float maxHealth = 10f;
    public float score;

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
        score = 0;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        soundManager.PlaySound(soundManager.hurt);
        if (currentHealth <= 0)
        {
            Destroy(player);
            IEnumerator coRoutine = FreezeScreen(2f);
            StartCoroutine(coRoutine);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Death");
        }
    }

    private IEnumerator FreezeScreen(float sec)
    {
        yield return new WaitForSeconds(2f);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health doesn't exceed maxHealth

        // Play heal sound
        soundManager.PlaySound(soundManager.healing);
    }

    public void ScoreUp()
    {
        score += 1;
    }
    void Update()
    {
        
    }
}
