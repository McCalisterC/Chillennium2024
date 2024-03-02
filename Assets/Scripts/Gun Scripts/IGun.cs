using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    public int damage { get; set; }
    public int time { get; set; }
    public float speed { get; set; }
    public float fireRate { get; set; }
    public IEnumerator Shoot();
    public void Disable();
    public void StartTimer();

}
