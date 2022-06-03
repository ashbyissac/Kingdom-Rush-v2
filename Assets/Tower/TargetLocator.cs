using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        TargetClosestEnemy();
        AimWeapon();
    }

    void TargetClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float maxDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestEnemy;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
