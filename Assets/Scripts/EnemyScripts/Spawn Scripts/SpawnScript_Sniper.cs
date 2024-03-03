using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript_Sniper : MonoBehaviour, ISpawns
{
    public GameObject[] spawnPoints;
    public GameObject sniper;
    //Spawn rate in seconds
    public float spawnRate = 30f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSniper());
    }

    IEnumerator SpawnSniper()
    {
        yield return new WaitForSeconds(spawnRate);
        int spawnUsed = Random.Range(0, spawnPoints.Length);
        Instantiate(sniper, spawnPoints[spawnUsed].transform.position, Quaternion.identity);
        StartCoroutine(SpawnSniper());
    }

    public void StopCoroutine()
    {
        this.StopAllCoroutines();
    }
}
