using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : TowerBase
{

    private void Start()
    {
        AttackSpeed = 1.5f;
        AttackTimer = AttackSpeed;
        Damage = 2;
        Range = 3;
    }
    void Update()
    {
        AttackTimer -= Time.deltaTime;
        if (!currTarget) return;
        ShootAt(currTarget);
        LookAt(currTarget);
    }

    
}
