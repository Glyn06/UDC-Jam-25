using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 targetPos;

    public void SetTarget(Transform newTarget)
    {
        targetPos = newTarget.position;
    }

    private void Start()
    {
        TravelToTarget();
    }

    private void Update()
    {
        CheckReachedTarget();
    }

    private void TravelToTarget()
    {
        Vector2 dir = (targetPos - (Vector2) transform.position).normalized;

        rb.velocity = dir * projectileSpeed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }

    private void CheckReachedTarget()
    {
        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            Destroy(gameObject);
    }
}
