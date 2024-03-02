using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Shotgun : MonoBehaviour
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
            ps_cc.shotGun.SetActive(true);
            ps_cc.currentGun = ps_cc.shotGun.GetComponent<IGun>();
            ps_cc.currentGun.StartTimer();
        }
    }

    private void Move()
    {
        this.GetComponent<Transform>().transform.position += new Vector3(-speed, 0, 0);
        if(this.GetComponent<Transform>().transform.position.x < -10.5)
        {
            Destroy(this.gameObject);
        }
    }
}
