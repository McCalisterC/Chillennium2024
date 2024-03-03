using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript_CharacterController : MonoBehaviour
{
    private PlayerScript_PlayerInput _input;

    public float upperLadderBound;
    public float lowerLadderBound;
    public float xAxis = -8.5f;

    public IGun currentGun;
    public GameObject baseGun;
    public GameObject shotGun;
    public GameObject sniper;


    [SerializeField] private int basePowerUpDropChance = 5;
    public int powerUpDropChance;
    public AudioSource rift;
    public AudioSource pickUp;
    public AudioClip[] audioClips;
    public AudioClip powerUPPickup;

    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        powerUpDropChance = basePowerUpDropChance;
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
        if (charTransform.position.y <= upperLadderBound &&
            charTransform.position.y >= lowerLadderBound)
        {
            MovePlayer();
            if (charTransform.position.y > upperLadderBound)
            {
                charTransform.position = new Vector3(xAxis, upperLadderBound, 0);
            }
            else if(charTransform.position.y < lowerLadderBound)
            {
                charTransform.position = new Vector3(xAxis, lowerLadderBound, 0);
            }
        }
    }

    void MovePlayer()
    {
        this.GetComponent<Transform>().transform.position += new Vector3(0, _input.move, 0);
        if(_input.move > 0)
        {
            playerAnim.SetBool("ClimbingUp", true);
            playerAnim.SetBool("DroppingDown", false);
        }
        else if (_input.move < 0)
        {
            playerAnim.SetBool("ClimbingUp", false);
            playerAnim.SetBool("DroppingDown", true);
        }
        else
        {
            playerAnim.SetBool("ClimbingUp", false);
            playerAnim.SetBool("DroppingDown", false);
        }
    }

    public void DisableCurrentGun()
    {
        currentGun.Disable();
    }

    public void EnableBaseWeapon()
    {

        GameObject.FindGameObjectWithTag("PlayerArm").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("SniperArm").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("ShotgunArm").GetComponent<SpriteRenderer>().enabled = false;
        baseGun.SetActive(true);
        currentGun = baseGun.GetComponent<IGun>();
        currentGun.StartTimer();
    }

    public void ResetDropRate()
    {
        powerUpDropChance = basePowerUpDropChance;
    }

    public void PlayPickUPAudio()
    {
        if (!rift.isPlaying)
        {

            rift.clip = powerUPPickup;
            rift.Play();
            if(Random.Range(0,5) == 0)
            {
                StartCoroutine(WaitUntilSoundIsDone());
            }
        }
    }

    private IEnumerator WaitUntilSoundIsDone()
    {
        yield return new WaitUntil(() => !rift.isPlaying);
        pickUp.clip = audioClips[Random.Range(0, audioClips.Length)];
        pickUp.Play();
    }
}
