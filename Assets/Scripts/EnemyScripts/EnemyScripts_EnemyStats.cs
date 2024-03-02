using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts_EnemyStats : MonoBehaviour
{
    public GameObject[] drops;
    public int health;
    public int dropChance = 5;
    public bool isHelicopter = false;

    private bool willDropPickup = false;
    public int pickUpDropped;

    private void Start()
    {
        if (isHelicopter)
        {
            willDropPickup=true;
            pickUpDropped = Random.Range(0, drops.Length);
        }
        else if (Random.Range(1, 100) <= dropChance)
        {
            willDropPickup = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
            pickUpDropped = Random.Range(0, drops.Length);
        }
    }

    public void Death()
    {
        if(willDropPickup)
            Instantiate(drops[pickUpDropped], this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
