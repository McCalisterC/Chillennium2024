using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryScript_Controller : MonoBehaviour
{
    public float speedX = 1;
    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speedX, 0, 0);
        if (this.GetComponent<Transform>().transform.position.x < -10.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}
