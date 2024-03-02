using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelicopterScript_Controller : MonoBehaviour
{
    public Transform endPosition;
    public float initialMoveSpeed = 2.0f; // Speed of the movement
    public float moveSpeed = 0.05f;

    public bool hasStartedShooting = false;

    void Start()
    {
        endPosition = GameObject.FindGameObjectWithTag("HelicopterEnter").transform;
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.Lerp(this.transform.position, endPosition.position, 0.05f);

        if((transform.position.y <= endPosition.position.y + 0.1 &&
            transform.position.y >= endPosition.position.y - 0.1) && !hasStartedShooting)
        {
            if(initialMoveSpeed != moveSpeed)
            {
                initialMoveSpeed = moveSpeed;
            }
            this.GetComponent<HelicopterGun>().StartShootSequence();
            hasStartedShooting = true;
        }
    }

    public void Reposition()
    {
        if (this.gameObject.transform.position.y > 2)
        {
            endPosition.position = new Vector3(this.transform.position.x, this.transform.position.y - ((float)Random.Range(17, 20)) / 10, 0);
        }
        else if(this.gameObject.transform.position.y < -2)
        {
            endPosition.position = new Vector3(this.transform.position.x, this.transform.position.y + ((float)Random.Range(17, 20)) / 10, 0);
        }
        else{
            int thing = Random.Range(-1, 1);
            if(thing < 0)
            {
                endPosition.position = new Vector3(this.transform.position.x, this.transform.position.y - ((float)Random.Range(17, 20)) / 10, 0);
            }
            else
            {
                endPosition.position = new Vector3(this.transform.position.x, this.transform.position.y + ((float)Random.Range(17, 20)) / 10, 0);
            }
        }
        hasStartedShooting = false;
    }
}
