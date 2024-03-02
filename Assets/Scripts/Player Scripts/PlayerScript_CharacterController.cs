using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript_CharacterController : MonoBehaviour
{
    private PlayerScript_PlayerInput _input;

    public float upperLadderBound;
    public float lowerLadderBound;

    public IGun currentGun;
    public GameObject baseGun;
    public GameObject shotGun;
    public GameObject sniper;


    // Start is called before the first frame update
    void Start()
    {
        currentGun = this.GetComponentInChildren<IGun>();
        _input = GetComponent<PlayerScript_PlayerInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Transform charTransform = this.GetComponent<Transform>().transform;
        if (charTransform.localPosition.y <= upperLadderBound &&
            charTransform.localPosition.y >= lowerLadderBound)
        {
            MovePlayer();
            if (charTransform.localPosition.y > upperLadderBound)
            {
                charTransform.localPosition = new Vector3(-6.74f, upperLadderBound, 0);
            }
            else if(charTransform.localPosition.y < lowerLadderBound)
            {
                charTransform.localPosition = new Vector3(-6.74f, lowerLadderBound, 0);
            }
        }
    }

    void MovePlayer()
    {
        this.GetComponent<Transform>().transform.localPosition += new Vector3(0, _input.move, 0);
    }

    public void DisableCurrentGun()
    {
        currentGun.Disable();
    }

    public void EnableBaseWeapon()
    {
        baseGun.SetActive(true);
        currentGun = baseGun.GetComponent<IGun>();
        currentGun.StartTimer();
    }
}
