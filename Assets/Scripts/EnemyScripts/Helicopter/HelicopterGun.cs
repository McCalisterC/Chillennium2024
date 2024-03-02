using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterGun : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public int amountPerEngage = 50;
    public int currentEngageAmount = 0;

    public GameObject bullet;
    public GameObject bulletSpawnObject;
    private Transform bulletSpawnTransform;

    public IEnumerator Shoot()
    {
        //Instatiate bullet at end of gun barrel
        GameObject bulletShot = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().shotByEnemy = true;
        //Add speed to bullet
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().speed = new Vector3(-speed, 0, 0);
        this.GetComponent<Animator>().SetTrigger("Shoot");
        currentEngageAmount--;

        yield return new WaitForSeconds(1 / fireRate);

        if (currentEngageAmount > 0)
            StartCoroutine(Shoot());
        else
        {
            this.gameObject.GetComponent<HelicopterScript_Controller>().Reposition();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnTransform = bulletSpawnObject.transform;
    }

    public void StartShootSequence()
    {
        currentEngageAmount = amountPerEngage;
        StartCoroutine(StartShootDelay());
    }

    IEnumerator StartShootDelay()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
    }
}
