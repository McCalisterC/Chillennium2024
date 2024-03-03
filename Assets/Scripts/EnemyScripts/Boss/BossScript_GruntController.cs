using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_GruntController : MonoBehaviour
{
    public float speed = 1;
    public float upperBound = 2.1f;
    public float lowerBound = -3.1f;
    public Vector3 nextPosition;

    public int phase = 1;

    public float deathForce = 2;
    private bool move = false;
    public bool death = false;

    public GameObject[] spawnsToDisable;

    public void StartSequence()
    {
        move = true;
    }

    void Move()
    {
        if (transform.position.y <= nextPosition.y + 0.1 && transform.position.y >= nextPosition.y - 0.1)
        {
            nextPosition = new Vector3(0, Random.Range(upperBound, lowerBound), 0);
        }

        if(nextPosition.y > this.transform.position.y)
            this.GetComponent<Transform>().transform.position += new Vector3(0, speed, 0);
        else
            this.GetComponent<Transform>().transform.position -= new Vector3(0, speed, 0);

        if (this.GetComponent<Transform>().transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (move && !death)
        {
            Move();
        }
    }

    public void DeathPhysics()
    {
        if (!death)
        {
            death = true;
            switch (phase)
            {
                case 1:
                    GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().phase1CurrentActive--;
                    break;
                case 2:
                    GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().phase2CurrentActive--;
                    break;
                case 3:
                    GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().phase3CurrentActive--;
                    break;
            }
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(deathForce, deathForce, 0));
        }
    }

}
