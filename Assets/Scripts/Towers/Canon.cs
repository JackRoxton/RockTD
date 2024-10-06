using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : TowerBase
{
    private void Start()
    {
        AttackSpeed = 3;
        AttackTimer = AttackSpeed;
        Damage = 4;
        Range = 4;
    }
    void Update()
    {
        AttackTimer -= Time.deltaTime;
        if (!currTarget) return;
        ShootAt(currTarget);
        LookAt(currTarget);
    }
}
