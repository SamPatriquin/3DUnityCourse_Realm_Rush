using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer = 3f;
    [SerializeField] int waveSize = 10;
    [SerializeField] GameObject enemyPrefab;
    void Start() {
        StartCoroutine(spawnWave());
    }

    IEnumerator spawnWave() {
        int enemyCount = 0;
        while (enemyCount < waveSize) {
            Vector3 spawnLocation = new Vector3(0, 5, 0);
            var spawnedEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
            spawnedEnemy.transform.parent = this.transform;
            ++enemyCount;
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
