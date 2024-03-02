using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript_BaseAR : MonoBehaviour, IGun
{
    public int _damage;
    public int damage { get => _damage; set => damage = _damage; }
    public int _time;
    public int time { get => _time; set => _time = value; }
    public float _speed;
    public float speed { get => _speed; set => _speed = value; }
    public float _fireRate;
    public float fireRate { get => _fireRate; set => _fireRate = value; }

    public GameObject bullet;
    public GameObject bulletSpawnObject;
    private Transform bulletSpawnTransform;

    public IEnumerator Shoot()
    {
        //Instatiate bullet at end of gun barrel
        GameObject bulletShot = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        //Add speed to bullet
        bulletShot.GetComponent<ProjectileScript_RegularBullet>().speed = new Vector3(speed, 0,0);

        yield return new WaitForSeconds(1 / fireRate);
        StartCoroutine(Shoot());
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnTransform = bulletSpawnObject.transform;
        StartCoroutine(Shoot());
    }

    public void StartTimer()
    {
        StartCoroutine(Shoot());
        return;
    }

}

   

