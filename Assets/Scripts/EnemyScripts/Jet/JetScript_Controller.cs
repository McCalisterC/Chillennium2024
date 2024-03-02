using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class JetScript_Controller : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speed,0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroyable")
        {
            collision.gameObject.GetComponent<EnemyScripts_EnemyStats>().Death();
        }
        else if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScripts_Stats>().Die();
            //Explode
        }
    }
}
