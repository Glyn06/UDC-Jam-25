using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private DamageZone damageZone;
    [SerializeField] private SpriteRenderer swordSpriteRenderer;
    [SerializeField] private Sprite swordWoosh;

    Sprite swordOriginal;

    private void Awake()
    {
        swordOriginal = swordSpriteRenderer.sprite;
    }

    public void EnableDamageZone()
    {
        swordSpriteRenderer.sprite = swordWoosh;
        damageZone.enabled = true;
    }

    public void DisableDamageZone()
    {
        swordSpriteRenderer.sprite = swordOriginal;
        damageZone.enabled = false;
    }

    public void DisableSword()
    {
        gameObject.SetActive(false);
    }
}
