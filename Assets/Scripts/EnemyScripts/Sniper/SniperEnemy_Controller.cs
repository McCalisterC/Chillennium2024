using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy_Controller : MonoBehaviour
{
    public float speed = 1;
    public GameObject tower;
    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speed, 0, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
