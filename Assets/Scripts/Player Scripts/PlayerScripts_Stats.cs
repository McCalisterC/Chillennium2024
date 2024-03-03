using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScripts_Stats : MonoBehaviour
{
    public bool debug = false;
    public bool hasShield = false;
    public GameObject arms;
    public AudioSource BGM;
    public AudioSource deathSound;
    public AudioClip deathJingle;
    public bool death = false;
    public Animator deathUI;
    public void Die(bool ignoreShield)
    {
        if (!death)
        {
            if (!debug && !hasShield || ignoreShield && !debug)
            {
                this.gameObject.tag = "Untagged";
                this.gameObject.GetComponent<PlayerInput>().enabled = false;
                this.gameObject.GetComponent<Animator>().SetTrigger("Die");
                GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().StopSpawns();
                GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().timeToSpawn = 100000;
                BGM.Stop();
                deathSound.Play();
                death = true;
                StartCoroutine(DeathUI());
            }
            else if (hasShield && !ignoreShield)
            {

                GameObject.FindGameObjectWithTag("Shield").GetComponent<SpriteRenderer>().enabled = false;
                hasShield = false;
            }
        }
    }

    public void DeactivateArms()
    {
        arms.SetActive(false);
        GameObject.FindGameObjectWithTag("SniperArm").SetActive(false);
        GameObject.FindGameObjectWithTag("ShotgunArm").SetActive(false);
    }

    IEnumerator DeathUI()
    {
        yield return new WaitForSeconds(2);
        BGM.clip = deathJingle;
        BGM.Play();
        deathUI.SetTrigger("Enter");
    }
}
