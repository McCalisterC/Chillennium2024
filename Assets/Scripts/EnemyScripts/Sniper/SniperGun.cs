using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperGun : MonoBehaviour
{
    public float speed;
    public float timeBetweenShots = 2f;
    public float aimTime;

    public GameObject bullet;
    public GameObject bulletSpawnObject;
    private Transform bulletSpawnTransform;

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBetweenShots);

        //Instatiate bullet at end of gun barrel
        GameObject bulletShot = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().shotByEnemy = true;
        //Add speed to bullet
        Vector3 direction = (this.GetComponentInChildren<MiscScript_LaserPoint>().savedPos
            - bulletShot.transform.position).normalized;
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().speed.x = direction.x * speed;
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().speed.y = direction.y * speed;
        this.GetComponentInChildren<Animator>().SetTrigger("Shoot");

        StartCoroutine(Aim());
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnTransform = bulletSpawnObject.transform;
        StartCoroutine(Aim());
    }

    IEnumerator Aim()
    {
        this.GetComponentInChildren<MiscScript_LaserPoint>().trackingPlayer = true;
        yield return new WaitForSeconds(aimTime);
        this.GetComponentInChildren<MiscScript_LaserPoint>().SavePos();
        this.GetComponentInChildren<MiscScript_LaserPoint>().trackingPlayer = false;
        StartCoroutine(Shoot());
    }
}
