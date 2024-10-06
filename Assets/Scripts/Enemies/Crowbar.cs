using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : EnemyBase
{
    GameObject Target;

    private void Start()
    {
        Target = GameManager.Instance.Player;
    }

    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character player = collision.gameObject.GetComponentInParent<Character>();
        if (player)
        {
                player.GetComponent<Rigidbody2D>().AddForce((player.transform.position - this.transform.position).normalized * 200f);
            
        }
    }

    private void OnDestroy()
    {
        EnemyManager.Instance.aliveEnemies--;
    }
}
