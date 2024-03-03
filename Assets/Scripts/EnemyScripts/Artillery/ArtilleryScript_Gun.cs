using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryScript_Gun : MonoBehaviour
{
    public float speed;

    public GameObject bullet;
    public GameObject bulletSpawnObject;
    private Transform bulletSpawnTransform;

    public void Shoot()
    {
        //Instatiate bullet at end of gun barrel
        GameObject bulletShot = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().shotByEnemy = true;
        //Add speed to bullet
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().speed = new Vector3(-speed,speed/1.5f,0);
        this.GetComponent<Animator>().SetTrigger("Shoot");
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnTransform = bulletSpawnObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ArtilleryShootTransform")
        {
            Shoot();
        }
    }
}
