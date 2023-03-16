using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : Item
{
    [SerializeField] private float forceMagnitude = 1;
    [SerializeField] private DamageZone damageZone;
    [SerializeField] private GameObject explotionPrefab;

    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Explode()
    {
        damageZone.enabled = true;
        Instantiate(explotionPrefab, transform.position, transform.rotation);

        Destroy(gameObject, 0.5f);
    }

    public override void Use(Vector2 direction)
    {
        direction = direction.normalized;

        rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

        animator.enabled = true;
    }
}
