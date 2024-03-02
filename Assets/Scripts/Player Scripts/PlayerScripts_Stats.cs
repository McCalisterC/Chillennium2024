using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts_Stats : MonoBehaviour
{
    public bool debug = false;
    public void Die()
    {
        if(!debug)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
