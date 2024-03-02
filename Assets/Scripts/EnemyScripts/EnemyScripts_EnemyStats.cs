using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts_EnemyStats : MonoBehaviour
{
    public GameObject[] drops;
    public int health;
    public int dropChanceIncreaseAmount = 1;
    public bool isHelicopter = false;
    private PlayerScript_CharacterController ps_cc;

    private bool willDropPickup = false;
    public int pickUpDropped;

    private void Start()
    {
        ps_cc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript_CharacterController>();
        if (isHelicopter)
        {
            willDropPickup = true;
            pickUpDropped = Random.Range(0, drops.Length);
        }
        else if (Random.Range(1, 100) <= ps_cc.powerUpDropChance)
        {
            willDropPickup = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
            pickUpDropped = Random.Range(0, drops.Length);
            ps_cc.ResetDropRate();
        }
        else
        {
            ps_cc.powerUpDropChance += dropChanceIncreaseAmount;
        }
    }

    public void Death()
    {
        if (willDropPickup)
        {
            Instantiate(drops[pickUpDropped], this.transform.position, Quaternion.identity);
            willDropPickup = false;
        }
        if(this.GetComponent<Animator>()  != null)
            this.GetComponent<Animator>().SetTrigger("Die");
        else
        {
            Destroy(this.gameObject);
        }
    }
}
