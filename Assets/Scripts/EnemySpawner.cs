using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyPath;
    public float timeBetweenEnemies = 4f;
    public float startDelay = 0f;

    void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyPath.GetChild(0).position, Quaternion.identity);

            var enemyFollowPath = enemy.GetComponent<EnemyFollowPath>();
            enemyFollowPath.m_enemyPath = enemyPath;

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }
}
