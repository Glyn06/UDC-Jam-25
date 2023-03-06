using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputActions inputActions;
    public float movementSpeed;
    public Rigidbody2D rb;

    private InputAction move;
    private Vector2 moveDirection;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * movementSpeed;
    }

    private void OnEnable()
    {
        move = inputActions.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
}
