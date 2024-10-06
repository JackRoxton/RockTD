using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : EnemyBase
{
    void Update()
    {
        if (currPath == null) return;
        this.transform.position = Vector2.MoveTowards(this.transform.position, currPath.position, Speed * Time.deltaTime);

        if (this.transform.position == currPath.position)
        {
            currPath = Path.NextPath(PathId);
            PathId++;
        }
    }

    private void OnDestroy()
    {
        EnemyManager.Instance.aliveEnemies--;
    }
}
