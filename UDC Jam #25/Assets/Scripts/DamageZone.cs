using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float damageTick = 0.5f;
    [SerializeField] private bool destroyAfterFirstCollision = false;
    [SerializeField] private Collider2D damageCollider;
    [SerializeField] private bool isZone = false;
    [SerializeField] private bool ignoreEnemy = false;

    private List<Health> toDamage;
    private float timer;

    private void Awake()
    {
        toDamage = new List<Health>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (toDamage.Count > 0 && timer >= damageTick)
        {
            for (int i = 0; i < toDamage.Count; i++)
            {
                toDamage[i].TakeDamage(damageAmount);
            }

            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ignoreEnemy)
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                return;
            }
        }

        Health health = other.GetComponent<Health>();

        if (health != null && isZone == true)
        {
            toDamage.Add(health);
        }

        if (health != null && isZone == false)
        {
            health.TakeDamage(damageAmount);

            if (destroyAfterFirstCollision == true)
                Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        toDamage.Remove(other.GetComponent<Health>());
    }

    private void OnEnable()
    {
        damageCollider.enabled = true;
    }

    private void OnDisable()
    {
        damageCollider.enabled = false;
    }
}
