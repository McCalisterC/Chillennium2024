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

    private void Start()
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
