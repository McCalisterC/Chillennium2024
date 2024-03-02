using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript_PlayerInput : MonoBehaviour
{

    PlayerScript_PlayerInput _inputs;
    CharacterController _characterController;

    // Character movement values
    public float move;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<float>());
    }

    public void MoveInput(float newMoveDirection)
    {
        move = newMoveDirection * speed;
    }
}
