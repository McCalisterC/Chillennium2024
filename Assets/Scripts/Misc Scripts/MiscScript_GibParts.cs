using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscScript_GibParts : MonoBehaviour
{
    public float forceY;
    public float forceX;

    private void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3 (forceX, forceY, 0));
    }
}
