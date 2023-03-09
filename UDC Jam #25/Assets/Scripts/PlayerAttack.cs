using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword;

    private void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            sword.SetActive(true);
    }

    private void Start()
    {
        PlayerInputManager.instance.attack.performed += Attack;
    }

    private void OnDisable()
    {
        PlayerInputManager.instance.attack.performed -= Attack;
    }
}
