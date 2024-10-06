using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : TowerBase
{
    private void Start()
    {
        AttackSpeed = 0.8f;
        AttackTimer = AttackSpeed;
        Damage = 1;
        Range = 2.5f;
    }
    void Update()
    {
        AttackTimer -= Time.deltaTime;
        if (!currTarget) return;
        ShootAt(currTarget);
        LookAt(currTarget);
    }
}
