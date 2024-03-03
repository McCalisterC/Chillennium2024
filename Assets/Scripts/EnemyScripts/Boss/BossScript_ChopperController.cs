using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BossScript_ChopperController : MonoBehaviour
{
    public Transform endPosition;
    public float initialMoveSpeed = 2.0f; // Speed of the movement
    public float moveSpeed = 0.05f;
    public int timeToSpawn = 180;
    public Transform spawnPoint;
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
    public Animator parent;
    public AudioSource BGM;
    public AudioClip winJingle;

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
                this.GetComponent<Animator>().SetTrigger("Spawn");
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
                this.GetComponent<Animator>().SetTrigger("Spawn");
                yield return new WaitForSeconds (1);
                this.GetComponent<Animator>().SetTrigger("Spawn");
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
                parent.gameObject.GetComponentInChildren<PlayerInput>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").gameObject.tag = "Untagged";
                parent.SetTrigger("Win");
                BGM.Stop();
                BGM.clip = winJingle;
                BGM.Play();
                StartCoroutine(ContinueUI());
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }

            else
            {

                this.GetComponent<Animator>().SetTrigger("Spawn");
                yield return new WaitForSeconds(1);
                this.GetComponent<Animator>().SetTrigger("Spawn");
                yield return new WaitForSeconds(1);
                this.GetComponent<Animator>().SetTrigger("Spawn");
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
        yield return new WaitForSeconds(4);
        continueUI.SetTrigger("Enter");
        Destroy(this.gameObject);
    }

    public void SpawnGrunt()
    {
        if(currentPhase == 1)
        {
            GameObject grunt = Instantiate(gruntObject, spawnPoint.transform.position, Quaternion.identity);
            BossScript_GruntController bs_gc = grunt.GetComponent<BossScript_GruntController>();
            bs_gc.nextPosition = new Vector3(bs_gc.transform.position.x, bs_gc.upperBound / bs_gc.lowerBound, 0);
            bs_gc.StartSequence();
            phase1CurrentActive++;
            phase1SpawnAmount--;
        }
        else if(currentPhase == 2)
        {
            GameObject grunt = Instantiate(gruntObject, spawnPoint.transform.position, Quaternion.identity);
            BossScript_GruntController bs_gc = grunt.GetComponent<BossScript_GruntController>();
            bs_gc.nextPosition = new Vector3(bs_gc.transform.position.x, bs_gc.upperBound / bs_gc.lowerBound, 0);
            bs_gc.phase = 2;
            bs_gc.StartSequence();
            phase2CurrentActive++;
            phase2SpawnAmount--;
        }
        else
        {
            GameObject grunt = Instantiate(gruntObject, spawnPoint.transform.position, Quaternion.identity);
            BossScript_GruntController bs_gc = grunt.GetComponent<BossScript_GruntController>();
            bs_gc.nextPosition = new Vector3(bs_gc.transform.position.x, bs_gc.upperBound / bs_gc.lowerBound, 0);
            bs_gc.phase = 3;
            bs_gc.StartSequence();
            phase3CurrentActive++;
            phase3SpawnAmount--;
        }
    }

}
