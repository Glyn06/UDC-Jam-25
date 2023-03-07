using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerInputActions inputActions;
    [SerializeField] private GameObject sword;

    private InputAction attack;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            sword.SetActive(true);
    }

    private void OnEnable()
    {
        attack = inputActions.Player.Attack;
        attack.performed += Attack;
        attack.Enable();
    }

    private void OnDisable()
    {
        attack.performed -= Attack;
        attack.Disable();
    }
}
