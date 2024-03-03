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


    // Start is called before the first frame update
    void Start()
    {
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
        if (charTransform.localPosition.y <= upperLadderBound &&
            charTransform.localPosition.y >= lowerLadderBound)
        {
            MovePlayer();
            if (charTransform.localPosition.y > upperLadderBound)
            {
                charTransform.localPosition = new Vector3(xAxis, upperLadderBound, 0);
            }
            else if(charTransform.localPosition.y < lowerLadderBound)
            {
                charTransform.localPosition = new Vector3(xAxis, lowerLadderBound, 0);
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
