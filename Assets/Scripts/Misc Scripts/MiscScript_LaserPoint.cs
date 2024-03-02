using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiscScript_LaserPoint : MonoBehaviour
{
    public bool trackingPlayer = false;
    public Vector3 savedPos = Vector3.zero;
    private void Start()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("PlayerHead").transform.position;
    }

    private void Update()
    {
        if (trackingPlayer)
        {
            this.transform.position = GameObject.FindGameObjectWithTag("PlayerHead").transform.position;
        }
        else
        {
            this.transform.position = savedPos;
        }
    }

    public void SavePos()
    {
        savedPos = GameObject.FindGameObjectWithTag("PlayerHead").transform.position;
    }
}
