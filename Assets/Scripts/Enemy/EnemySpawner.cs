using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject spider;
    //[SerializeField] GameObject rabbit;

    [SerializeField] private float spiderInterval = 3f;
    //[SerializeField] private float rabbitInterval = 5f;

    [SerializeField] public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spiderInterval, spider));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
