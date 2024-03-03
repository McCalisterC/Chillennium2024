using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperEnemy_Controller : MonoBehaviour
{
    public float speed = 1;
    public GameObject tower;
    public GameObject sniperSprite;


    public Transform targetSprite;
    public float maxAngle = 45.0f;

    private void Start()
    {
    }

    void Move()
    {
        this.GetComponent<Transform>().transform.position -= new Vector3(speed, 0, 0);
    }

    private void FixedUpdate()
    {
        if (targetSprite)
        {
            Vector3 direction = targetSprite.position - sniperSprite.transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            sniperSprite.transform.rotation = Quaternion.Euler(180, 180, angle);
        }
        Move();
    }
}
