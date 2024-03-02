using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript_Controller : MonoBehaviour
{
    public float speedX = 1;
    public float speedY = 1;
    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speedX, speedY, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
