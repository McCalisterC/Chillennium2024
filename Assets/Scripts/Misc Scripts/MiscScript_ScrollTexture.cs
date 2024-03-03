using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscScript_ScrollTexture : MonoBehaviour
{
    public float speed = 0.5f;
    public float xDifference = 0;

    public GameObject opposite;
    

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speed, 0, 0);
        if(this.GetComponent<Transform>().position.x < -25)
        {
            this.transform.position = opposite.transform.position + new Vector3(xDifference, 0, 0);
        }
    }
}

