using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyGun : MonoBehaviour
{
    public float speed;
    public float fireRate;

    public GameObject bullet;
    public GameObject bulletSpawnObject;
    private Transform bulletSpawnTransform;

    public IEnumerator Shoot()
    {
        //Instatiate bullet at end of gun barrel
        GameObject bulletShot = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().shotByEnemy = true;
        //Add speed to bullet
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().speed = new Vector3(-speed,0,0);

        yield return new WaitForSeconds(1 / fireRate);
        StartCoroutine(Shoot());
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnTransform = bulletSpawnObject.transform;
        StartCoroutine(Shoot());
    }
}
