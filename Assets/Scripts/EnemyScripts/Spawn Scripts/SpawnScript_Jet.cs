using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript_Jet: MonoBehaviour
{
    public GameObject[] lanes;
    //Spawn rate in seconds
    public float spawnRate = 25f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnJet());
    }

    IEnumerator SpawnJet()
    {
        yield return new WaitForSeconds(spawnRate);
        int laneUsed = Random.Range(0, lanes.Length);
        lanes[laneUsed].gameObject.SetActive(true);
        StartCoroutine(SpawnJet());
    }
}
