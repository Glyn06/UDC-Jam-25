using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputActions inputActions;
    public float movementSpeed;
    public Rigidbody2D rb;
    public Camera cam;

    private InputAction move;
    private Vector2 moveDirection;

    private InputAction mousePos;
    private Vector2 mousePosition;

    private Vector2 playerPos;
    private Vector2 facingDirection;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        mousePosition = mousePos.ReadValue<Vector2>();

        playerPos = cam.WorldToScreenPoint(transform.position);
        facingDirection = (mousePosition - playerPos).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * movementSpeed;

        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }

    private void OnEnable()
    {
        move = inputActions.Player.Move;
        move.Enable();

        mousePos = inputActions.Player.MousePos;
        mousePos.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        mousePos.Disable();
    }
}
