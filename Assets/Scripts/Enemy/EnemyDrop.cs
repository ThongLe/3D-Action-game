using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDrop : MonoBehaviour
{
    public float dropChance = 0.5f; // Chance of dropping the healing cube (0.0 to 1.0)
    public float dropLifetime = 10f;

    private void OnDestroy()
    {
        // Check if the enemy should drop the healing cube based on the dropChance
        if (Random.value < dropChance)
        {
            DropHealingCube();
        }
        if (Random.value >= dropChance)
        {
            DropSupportCube();
        }
    }

    private void DropHealingCube()
    {
        // Instantiate the healing cube at the enemy's position with some offset
        Vector3 spawnPosition = transform.position + (Vector3.up * 3); // Offset by one unit in the y-axis
        GameObject healingCube = Instantiate(Resources.Load("Prefabs/healing") as GameObject, spawnPosition, Quaternion.identity);
        Destroy(healingCube, dropLifetime); // Destroy the healing cube after dropLifetime seconds
    }
    private void DropSupportCube()
    {
        // Instantiate the healing cube at the enemy's position with some offset
        Vector3 spawnPosition = transform.position + (Vector3.up * 3); // Offset by one unit in the y-axis
        GameObject supportCube = Instantiate(Resources.Load("Prefabs/Support") as GameObject, spawnPosition, Quaternion.identity);
        Destroy(supportCube, dropLifetime); // Destroy the healing cube after dropLifetime seconds
    }
}
