using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BossScript_ChopperController : MonoBehaviour
{
    public Transform endPosition;
    public float initialMoveSpeed = 2.0f; // Speed of the movement
    public float moveSpeed = 0.05f;
    public int timeToSpawn = 180;
    public int phase1SpawnAmount = 6;
    public int phase1CurrentActive = 0;
    public int phase2SpawnAmount = 12;
    public int phase2CurrentActive = 0;
    public int phase3SpawnAmount = 18;
    public int phase3CurrentActive = 0;
    private int currentPhase = 1;

    private bool spawned = false;
    public GameObject gruntObject;
    public GameObject[] spawnsToStop;
    public Animator continueUI;

    void Start()
    {
        endPosition = GameObject.FindGameObjectWithTag("BossLand").transform;
        StartCoroutine(Countdown());
    }
    void FixedUpdate()
    {
        if (spawned)
            Move();
    }

    void Move()
    {
        transform.position = Vector3.Lerp(this.transform.position, endPosition.position, 0.05f);
    }

    IEnumerator Phase1()
    {
        if (currentPhase == 1)
        {
            yield return new WaitForSeconds(1);

            if (phase1SpawnAmount <= 0 && phase1CurrentActive == 0)
            {
                currentPhase = 2;
                StartCoroutine(Phase2());
            }

            else
            {
                GameObject grunt = Instantiate(gruntObject, this.transform.position, Quaternion.identity);
                BossScript_GruntController bs_gc = grunt.GetComponent<BossScript_GruntController>();
                bs_gc.nextPosition = new Vector3(bs_gc.transform.position.x, bs_gc.upperBound / bs_gc.lowerBound, 0);
                bs_gc.StartSequence();
                phase1CurrentActive++;
                phase1SpawnAmount--;
            }

            yield return new WaitForSeconds(1);

            yield return new WaitUntil(() => phase1CurrentActive == 0);

            StartCoroutine(Phase1());
        }
    }

    IEnumerator Phase2()
    {
        if (currentPhase == 2)
        {
            yield return new WaitForSeconds(1);

            if (phase2SpawnAmount <= 0 && phase2CurrentActive == 0)
            {
                currentPhase = 3;
                StartCoroutine(Phase3());
            }

            else
            {
                GameObject grunt = Instantiate(gruntObject, this.transform.position, Quaternion.identity);
                BossScript_GruntController bs_gc = grunt.GetComponent<BossScript_GruntController>();
                float temp = bs_gc.upperBound / bs_gc.lowerBound;
                bs_gc.GetComponent<BossScript_GruntController>().phase = 2;
                bs_gc.nextPosition = new Vector3(bs_gc.transform.position.x, temp / bs_gc.lowerBound, 0);
                bs_gc.upperBound = temp;
                bs_gc.StartSequence();
                yield return new WaitForSeconds(1);
                GameObject grunt2 = Instantiate(gruntObject, this.transform.position, Quaternion.identity);
                BossScript_GruntController bs_gc2 = grunt2.GetComponent<BossScript_GruntController>();
                bs_gc2.GetComponent<BossScript_GruntController>().phase = 2;
                bs_gc2.nextPosition = new Vector3(bs_gc.transform.position.x, bs_gc.upperBound / temp, 0);
                bs_gc2.lowerBound = temp;
                bs_gc2.StartSequence();
                phase2CurrentActive += 2;
                phase2SpawnAmount -= 2;
            }

            yield return new WaitForSeconds(1);

            yield return new WaitUntil(() => phase2CurrentActive == 0);

            StartCoroutine(Phase2());
        }
    }

    IEnumerator Phase3()
    {
        if (currentPhase == 3)
        {
            yield return new WaitForSeconds(1);

            if (phase3SpawnAmount <= 0 && phase3CurrentActive == 0)
            {
                GameObject.FindGameObjectWithTag("Player").gameObject.tag = "Untagged";
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerInput>().enabled = false;
                StartCoroutine(ContinueUI());
                Destroy(this.gameObject);
            }

            else
            {
                GameObject grunt = Instantiate(gruntObject, this.transform.position, Quaternion.identity);
                BossScript_GruntController bs_gc = grunt.GetComponent<BossScript_GruntController>();
                bs_gc.GetComponent<BossScript_GruntController>().phase = 3;
                bs_gc.nextPosition = new Vector3(bs_gc.transform.position.x, (bs_gc.upperBound / 3) / bs_gc.lowerBound, 0);
                bs_gc.upperBound = (bs_gc.upperBound / 3);
                bs_gc.StartSequence();

                yield return new WaitForSeconds(1);

                GameObject grunt2 = Instantiate(gruntObject, this.transform.position, Quaternion.identity);
                BossScript_GruntController bs_gc2 = grunt2.GetComponent<BossScript_GruntController>();
                bs_gc2.GetComponent<BossScript_GruntController>().phase = 3;
                bs_gc2.nextPosition = new Vector3(bs_gc.transform.position.x, (bs_gc.upperBound / 3) / (bs_gc.lowerBound / 3), 0);
                bs_gc2.upperBound = (bs_gc.upperBound / 3);
                bs_gc2.lowerBound = (bs_gc.lowerBound / 3);
                bs_gc2.StartSequence();


                yield return new WaitForSeconds(1);

                GameObject grunt3 = Instantiate(gruntObject, this.transform.position, Quaternion.identity);
                BossScript_GruntController bs_gc3 = grunt3.GetComponent<BossScript_GruntController>();
                bs_gc3.GetComponent<BossScript_GruntController>().phase = 3;
                bs_gc3.nextPosition = new Vector3(bs_gc.transform.position.x, bs_gc.upperBound / (bs_gc.lowerBound / 3), 0);
                bs_gc3.lowerBound = (bs_gc.lowerBound / 3);
                bs_gc3.StartSequence();

                phase3CurrentActive += 3;
                phase3SpawnAmount -= 3;
            }

            yield return new WaitForSeconds(1);

            yield return new WaitUntil(() => phase3CurrentActive == 0);

            StartCoroutine(Phase3());
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timeToSpawn);
        StopSpawns();
        spawned = true;
        StartCoroutine(WaitForChopper());
    }

    IEnumerator WaitForChopper()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(Phase1());
    }


    public void StopSpawns()
    {
        foreach (GameObject spawn in spawnsToStop)
        {
            spawn.GetComponent<ISpawns>().StopCoroutine();
        }
    }
    IEnumerator ContinueUI()
    {
        yield return new WaitForSeconds(2);
        continueUI.SetTrigger("Enter");
    }

}
