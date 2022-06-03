using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 3;
    [SerializeField] int difficultyRamp = 2;

    int currentHitPoints;
    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;    
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints < 1)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
