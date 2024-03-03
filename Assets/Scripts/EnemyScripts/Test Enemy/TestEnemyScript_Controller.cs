using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript_Controller : MonoBehaviour
{
    public float speedX = 1;
    public float speedY = 1;

    public float deathForce = 2;
    private bool death = false;
    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speedX, speedY, 0);
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
        this.gameObject.GetComponentInChildren<TestEnemyGun>().StopShoot();
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector3(deathForce, deathForce, 0));
    }
}
