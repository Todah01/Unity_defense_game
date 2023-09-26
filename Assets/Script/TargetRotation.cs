using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    private void Start() {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    private void Update() {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
