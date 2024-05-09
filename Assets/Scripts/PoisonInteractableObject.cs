using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonInteractableObject : MonoBehaviour
{
    public bool playerInRange;
    public string ItemName;
    public string GetItemName()
    {
        return ItemName;
    }
    public float damageAmountPerTick = 1f; // Damage per tick
    public float tickInterval = 3f; // Time interval between each damage tick
    public int numberOfTicks = 3; // Number of damage ticks

    private Collider collider;
    private Renderer renderer;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable collider and renderer
            collider.enabled = false;
            renderer.enabled = false;
            StartCoroutine(ApplyPoisonDamage());
            
        }
    }

    private IEnumerator ApplyPoisonDamage()
    {
        // Calculate the delay between each tick
        // Apply damage for each tick
        float delayBetweenTicks = tickInterval / numberOfTicks;

        // Apply damage for each tick
        for (int i = 0; i < numberOfTicks; i++)
        {
            PlayerStatus.Instance.TakeDamage(damageAmountPerTick);
            yield return new WaitForSeconds(delayBetweenTicks);
        }
        Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
