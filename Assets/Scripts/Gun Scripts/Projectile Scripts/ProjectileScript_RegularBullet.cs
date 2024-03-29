using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript_RegularBullet : MonoBehaviour
{
    public int damage = 1;
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
            enemyStats.health -= damage;
            if (enemyStats.health <= 0)
            {
                enemyStats.Death();
            }
            else if(collision.GetComponent<SniperEnemy_Controller>() == null)
            {
                Animator otherAnim = collision.GetComponent<Animator>();
                try
                {
                    otherAnim.SetTrigger("Hit");
                }
                catch (UnassignedReferenceException ex)
                {
                    Debug.Log(ex);
                }
            }
            Destroy(gameObject);
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
