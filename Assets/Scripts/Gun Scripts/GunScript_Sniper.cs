using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunScript_Sniper : MonoBehaviour, IGun
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
        //Instatiate sniper bullet at end of gun barrel
        GameObject bulletShotForward = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        //Add speed to bullet
        bulletShotForward.GetComponent<ProjectileScript_SniperBullet>().speed = new Vector3(speed, 0, 0);
        GameObject.FindGameObjectWithTag("PlayerArm").GetComponent<Animator>().SetTrigger("Shoot");

        yield return new WaitForSeconds(1 / fireRate);
        StartCoroutine(Shoot());
    }


    public void Disable()
    {
        StopCoroutine(Timer());
        this.gameObject.SetActive(false);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        Disable();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript_CharacterController>().EnableBaseWeapon();
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private void OnEnable()
    {
        bulletSpawnTransform = bulletSpawnObject.transform;
        StartCoroutine(Shoot());
    }
}

   

