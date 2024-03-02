using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscScript_JetLaneAnim : MonoBehaviour
{
    public GameObject jetSpawnPoint;
    public GameObject jet;

    public void SpawnJet()
    {
        Instantiate(jet, jetSpawnPoint.transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
}
