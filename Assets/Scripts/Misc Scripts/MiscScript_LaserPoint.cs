using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiscScript_LaserPoint : MonoBehaviour
{
    private void Start()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("PlayerHead").transform.position;
    }
}
