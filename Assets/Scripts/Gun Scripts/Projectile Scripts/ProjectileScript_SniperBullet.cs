using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript_SniperBullet : MonoBehaviour
{
    public int damage = 8;
    public Vector3 speed = Vector3.zero;
    public bool shotByEnemy = false;

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyable" && !shotByEnemy)
        {
            EnemyScripts_EnemyStats enemyStats = collision.GetComponent<EnemyScripts_EnemyStats>();
            int temp = enemyStats.health;
            enemyStats.health -= damage;
            damage -= temp;
            if (enemyStats.health <= 0)
            {
                enemyStats.Death();
            }
            if(damage <= 0)
            {
                Destroy(gameObject);
            }
        }

        else if(collision.tag == "Player" && shotByEnemy)
        {
            collision.GetComponent<PlayerScripts_Stats>().Die(false);
        }
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }

    private void MoveBullet()
    {
        if (this.GetComponent<Transform>().transform.position.x >= 10.5 ||
            this.GetComponent<Transform>().transform.position.x <= -10.5)
        {
            Despawn();
        }
        else
            this.GetComponent<Transform>().transform.position += speed;
    }
}
