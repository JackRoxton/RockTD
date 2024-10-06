using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        Boss Boss = collision.gameObject.GetComponent<Boss>();
        if(Boss)
        {
            GameManager.Instance.Life = 0;
            Destroy(enemy.gameObject);
        }
        if (enemy)
        {
            GameManager.Instance.LoseHp(1);
            Destroy(enemy.gameObject);
        }
    }
}
