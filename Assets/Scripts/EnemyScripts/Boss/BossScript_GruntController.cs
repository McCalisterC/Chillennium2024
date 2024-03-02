using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_GruntController : MonoBehaviour
{
    public float speed = 1;
    public float upperBound;
    public float lowerBound;

    public float deathForce = 2;
    private bool death = false;
    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(0, speed, 0);
        if (this.GetComponent<Transform>().transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!death)
        {
            Move();
        }
    }

    public void DeathPhysics()
    {
        death = true;
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector3(deathForce, deathForce, 0));
    }
}
