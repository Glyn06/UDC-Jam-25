using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 moveDirection;

    private Vector2 mousePosition;

    private Vector2 playerPos;
    private Vector2 facingDirection;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Update()
    {
        moveDirection = PlayerInputManager.instance.move.ReadValue<Vector2>();

        mousePosition = PlayerInputManager.instance.mousePos.ReadValue<Vector2>();

        playerPos = cam.WorldToScreenPoint(transform.position);
        facingDirection = (mousePosition - playerPos).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * movementSpeed;

        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
}
