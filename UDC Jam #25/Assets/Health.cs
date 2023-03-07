using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmgTaken)
    {
        currentHealth -= dmgTaken;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
