using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScripts_TestEnemy : MonoBehaviour
{
    public float spawnX = 6f;
    public float spawnY = 6f;
    public float spawnRateLowerBound = 1.0f;
    public float spawnRateUpperBound = 2.0f;

    public GameObject enemyToSpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        float spawnRate = Random.Range(spawnRateLowerBound, spawnRateUpperBound);
        yield return new WaitForSeconds(spawnRate);
        float randSpawnX = this.GetComponent<Transform>().transform.position.x + Random.Range(-spawnX, spawnX);
        float randSpawnY = this.GetComponent<Transform>().transform.position.y + Random.Range(-spawnY, spawnY);
        Vector3 spawnPosition = new Vector3(randSpawnX, randSpawnY, 0);
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
}
