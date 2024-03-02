using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_ChopperController : MonoBehaviour
{
    public Transform endPosition;
    public float initialMoveSpeed = 2.0f; // Speed of the movement
    public float moveSpeed = 0.05f;
    public int phase1SpawnAmount = 6;
    public int phase1CurrentActive = 0;
    public int phase2SpawnAmount = 12;
    public int phase2CurrentActive = 0;
    public int phase3SpawnAmount = 18;
    public int phase3CurrentActive = 0;
    private int currentPhase = 1;

    public GameObject[] spawnsToStop;

    void Start()
    {
        endPosition = GameObject.FindGameObjectWithTag("BossLand").transform;
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.Lerp(this.transform.position, endPosition.position, 0.05f);
        if (transform.position.y == endPosition.position.y)
        {
            StartCoroutine(Phase1());
        }
    }

    IEnumerator Phase1()
    {
        if (currentPhase == 1)
        {
            if (phase1SpawnAmount <= 0 && phase1CurrentActive == 0)
            {
                currentPhase = 2;
                StartCoroutine(Phase2());
            }

            //Instantiate boss goon
            phase1CurrentActive++;

            while (phase1CurrentActive >= 1)
            {
                yield return new WaitUntil(() => phase1CurrentActive == 0);
            }

            StartCoroutine(Phase1());
        }
    }

    IEnumerator Phase2()
    {
        if (currentPhase == 2)
        {
            if (phase2SpawnAmount <= 0 && phase2CurrentActive == 0)
            {
                currentPhase = 3;
                StartCoroutine(Phase3());
            }

            //Instantiate boss goon
            phase1CurrentActive++;

            while (phase2CurrentActive >= 2)
            {
                yield return new WaitUntil(() => phase2CurrentActive == 0);
            }

            StartCoroutine(Phase2());
        }
    }

    IEnumerator Phase3()
    {
        if (currentPhase == 3)
        {
            if (phase3SpawnAmount <= 0 && phase3CurrentActive == 0)
            {
                //End game
            }

            //Instantiate boss goon
            phase3CurrentActive++;

            while (phase1CurrentActive >= 3)
            {
                yield return new WaitUntil(() => phase3CurrentActive == 0);
            }

            StartCoroutine(Phase3());
        }
    }
}
