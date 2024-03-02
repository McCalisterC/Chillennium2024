using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Sniper : MonoBehaviour
{
    public float speed = 0.1f;
    private void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript_CharacterController ps_cc = collision.gameObject.GetComponent<PlayerScript_CharacterController>();
        if (collision.tag == "Player")
        {
            ps_cc.DisableCurrentGun();
            ps_cc.sniper.SetActive(true);
            ps_cc.currentGun = ps_cc.sniper.GetComponent<IGun>();
            ps_cc.currentGun.StartTimer();
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
