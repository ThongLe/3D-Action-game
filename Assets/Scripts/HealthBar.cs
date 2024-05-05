using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Text health;

    public GameObject playerState;

    private float currentHealth, maxHealth;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        currentHealth = playerState.GetComponent<PlayerStatus>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerStatus>().maxHealth;
        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;
        health.text = currentHealth + "/" + maxHealth;
    }
}
