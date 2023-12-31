using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy die.")][SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    Enemy enemy;

    private void OnEnable() {
        currentHitPoints = maxHitPoints;
    }
    private void Start() {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0){
            this.gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
