using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts_Stats : MonoBehaviour
{
    public bool debug = false;
    public bool hasShield = false;
    public void Die(bool ignoreShield)
    {
        if(!debug && !hasShield || ignoreShield && !debug)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        else if (hasShield && !ignoreShield)
        {
            hasShield = false;
        }
    }
}
