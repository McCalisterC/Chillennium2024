using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscScript_ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int distanceScore = 0;
    public int killScore = 0;

    IEnumerator distanceScoreCount()
    {
        yield return new WaitForSeconds(1);
        distanceScore += 1000;
    }
}
