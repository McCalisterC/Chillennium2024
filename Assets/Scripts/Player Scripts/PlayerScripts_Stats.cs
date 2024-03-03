using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts_Stats : MonoBehaviour
{
    public bool debug = false;
    public bool hasShield = false;
    public GameObject arms;
    public void Die(bool ignoreShield)
    {
        if (!debug && !hasShield || ignoreShield && !debug)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Die");
            GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().StopSpawns();
            GameObject.FindGameObjectWithTag("BossChopper").GetComponent<BossScript_ChopperController>().timeToSpawn = 100000;

        }
        else if (hasShield && !ignoreShield)
        {
            hasShield = false;
        }
    }

    public void DeactivateArms()
    {
        arms.SetActive(false);
    }
}
