using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float waitTime = 2f;
    void Start()
    {
        // Start the loop once when the game begins
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs != null && enemyPrefabs.Length > 0)
        {
            // pick random from enemy list
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex]); 
        } 
    }
}
