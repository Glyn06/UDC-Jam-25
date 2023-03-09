using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool isPickedUp = false;

    public virtual void Use() { }
    public virtual void Use(Vector2 direction) { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerItem playerItem = collision.GetComponent<PlayerItem>();

        if (playerItem != null && isPickedUp == false)
        {
            isPickedUp = playerItem.TryPickUpItem(this);
        }
    }
}
