using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private Transform origin;

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    public void SpawnProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab, origin.position, origin.rotation).GetComponent<Projectile>();

        if (projectile != null)
            projectile.SetTarget(target);
    }
}
