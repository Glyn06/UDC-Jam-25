using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AddRandomForceAtStart : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float x;
        float y;

        x = Random.Range(rb.mass * -2, rb.mass * 2);
        y = Random.Range(rb.mass * -2, rb.mass * 2);

        Vector2 force = new Vector2(x, y);

        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
