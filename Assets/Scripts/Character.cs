using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed;
    Vector3 Movement;

    public float BiteCD = 4;
    public float BiteTimer = 4;
    bool BiteFlag = false;
    public float BiteDmg = 4;

    public float SmashCD = 10;
    public float SmashTimer = 10;
    bool SmashFlag = false;
    public float SmashStrength = 500f;

    bool faceR = true;

    /*public float RainCD = 30;
    public float RainTimer = 30;
    public bool RainFlag = false;*/

    List<GameObject> enemiesInRadius = new List<GameObject>();

    void Update()
    {
        if (GameManager.Instance.inMenu) return;

        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody2D>().velocity *= 0.98f;

        this.transform.position += Movement * Speed * Time.deltaTime;

        if(Movement.x > 0 && !faceR)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            faceR = true;
        }
        else if (Movement.x < 0 && faceR)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            faceR = false;
        }

        if (BiteTimer <= 0)
            BiteFlag = true;
        else
            BiteTimer -= Time.deltaTime;

        if (SmashTimer < 0)
            SmashFlag = true;
        else
            SmashTimer -= Time.deltaTime;

        /*if (RainTimer < 0)
            RainFlag = true;
        else
            RainTimer -= Time.deltaTime;*/

        if (Input.GetKeyDown(KeyCode.E) && BiteFlag)
        {
            Bite();
            SoundManager.Instance.Play("Eat");
            BiteFlag = false;
            BiteTimer = BiteCD; 
        }
        if (Input.GetKeyDown(KeyCode.Space) && SmashFlag)
        {
            Smash();
            SoundManager.Instance.Play("Smash");
            SmashFlag = false;
            SmashTimer = SmashCD;
        }
        /*if (Input.GetKeyDown(KeyCode.R) && RainFlag)
        {
            Rain();
            RainFlag = false;
            RainTimer = RainCD;
        }*/
    }

    void Bite()
    {
        for(int i = 0; i < enemiesInRadius.Count; i++)
        {
            enemiesInRadius[i].GetComponent<EnemyBase>().TakeDamage(BiteDmg);
        }
    }

    void Smash()
    {
        foreach (GameObject t in enemiesInRadius)
        {
            t.GetComponent<Rigidbody2D>().AddForce((t.transform.position - this.transform.position).normalized*SmashStrength);
        }
    }

    /*void Rain()
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy)
        {
            if(!enemy.GetComponent<Crowbar>())
                Physics2D.IgnoreCollision(this.GetComponentInChildren<BoxCollider2D>(), collision);
            enemiesInRadius.Add(enemy.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy)
        {
            if (enemiesInRadius.Contains(enemy.gameObject))
            {
                enemiesInRadius.Remove(enemy.gameObject);
            }
        }
    }
}
