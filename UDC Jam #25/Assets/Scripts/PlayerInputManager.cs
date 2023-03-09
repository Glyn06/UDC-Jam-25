using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    #region Singleton
    public static PlayerInputManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        inputActions = new PlayerInputActions();

        useItem = inputActions.Player.UseItem;
        useItem.Enable();

        attack = inputActions.Player.Attack;
        attack.Enable();

        move = inputActions.Player.Move;
        move.Enable();

        mousePos = inputActions.Player.MousePos;
        mousePos.Enable();
    }
    #endregion

    private PlayerInputActions inputActions;

    [HideInInspector] public InputAction useItem;
    [HideInInspector] public InputAction attack;
    [HideInInspector] public InputAction move;
    [HideInInspector] public InputAction mousePos;

    private void OnDisable()
    {
        useItem.Disable();
        attack.Disable();
        move.Disable();
        mousePos.Disable();
    }

    public PlayerInputActions GetInputActions() { return inputActions; }
}
