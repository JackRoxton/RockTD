using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingProjectile : ProjectileBase
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!currTarget)
            Destroy(this.gameObject);
        Spin();
        GoToEnemy();
    }
}
