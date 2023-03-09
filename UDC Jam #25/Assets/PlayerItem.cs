using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItem : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;

    private Item currentItem;

    private void Start()
    {
        PlayerInputManager.instance.useItem.performed += UseItem;  
    }

    private void Update()
    {
        if (currentItem != null)
        {
            currentItem.transform.position = itemHolder.transform.position;
            currentItem.transform.rotation = itemHolder.transform.rotation;
        }
    }

    public bool TryPickUpItem(Item newItem)
    {
        if (currentItem != null)
            return false;

        currentItem = newItem;
        currentItem.transform.parent = itemHolder;

        return true;
    }

    private void UseItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentItem != null)
            {
                currentItem.Use(PlayerInputManager.instance.GetInputActions().Player.MousePos.ReadValue<Vector2>() *
                                gameObject.transform.right);
                currentItem = null;
            }
        }
    }

    private void OnDisable()
    {
        PlayerInputManager.instance.useItem.performed -= UseItem;
    }
}
