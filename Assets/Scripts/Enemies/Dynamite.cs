using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : EnemyBase
{
    List<GameObject> list = new List<GameObject>();
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

    public void TakeDamaged(float damage)
    {
        CurrentHp -= damage;
        if(CurrentHp <= 0)
        {
            SoundManager.Instance.Play("Smash");
            for (int i = 0; i < list.Count; i++)
            {
                list[i].GetComponent<EnemyBase>().TakeDamage(5);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy)
        {
            list.Add(enemy.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy)
        {
            if(list.Contains(enemy.gameObject))
                list.Remove(enemy.gameObject);
        }
    }
}
