using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiscScript_ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int distanceScore = 0;
    public int killScore = 0;

    public void Start()
    {
        StartCoroutine(distanceScoreCount());
    }

    IEnumerator distanceScoreCount()
    {
        yield return new WaitForSeconds(1);
        distanceScore += 100;
        StartCoroutine(distanceScoreCount());
    }

    public void FinalizeDistance()
    {
        StopCoroutine(distanceScoreCount());
    }
}
