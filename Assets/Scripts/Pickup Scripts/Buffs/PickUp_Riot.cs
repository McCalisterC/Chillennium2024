using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Riot : MonoBehaviour
{
    public float speed = 0.1f;
    private void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerScripts_Stats>().hasShield = true;
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        if(this.GetComponent<Transform>().transform.position.y < 3)
        {
            this.GetComponent<Transform>().transform.position += new Vector3(-speed, 0, 0);
        }
        else
            this.GetComponent<Transform>().transform.position += new Vector3(-speed, -speed, 0);

        if (this.GetComponent<Transform>().transform.position.x < -10.5)
        {
            Destroy(this.gameObject);
        }
    }
}
