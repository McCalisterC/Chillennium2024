using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript_Basic : MonoBehaviour, ISpawns
{
    //Spawn rate in seconds
    public int spawnRate = 20;
    public GameObject objectToSpawn;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnRate);
        Instantiate(objectToSpawn, this.transform.position, Quaternion.identity);
        StartCoroutine(Spawn());
    }

    public void StopCoroutine()
    {
        this.StopAllCoroutines();
    }
}
