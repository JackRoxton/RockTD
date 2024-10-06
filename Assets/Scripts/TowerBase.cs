using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerBase : MonoBehaviour
{
    public GameObject turret;
    public float Damage;
    public GameObject projectile;
    public float AttackSpeed;
    public float AttackTimer;
    public float Range;
    public int Price;
    protected EnemyBase currTarget;

    //bool FaceR = true;

    private void Start()
    {
        this.GetComponent<CircleCollider2D>().radius = Range;
    }

    public void RangeChange()
    {
        this.GetComponent<CircleCollider2D>().radius = Range;
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (currTarget != null)
            return;
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            currTarget = enemy;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy == currTarget)
        {
            currTarget = null;
        }
    }

    protected void LookAt(EnemyBase Enemy)
    {
        Vector2 targ = currTarget.transform.position;
        Vector2 objectPos = turret.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;
        /*if(objectPos.x < targ.x && !FaceR)
        {
            turret.transform.localScale = new Vector3(turret.transform.localScale.x, -turret.transform.localScale.y, turret.transform.localScale.z);
            FaceR = true;
        }
        else if(objectPos.x > targ.x && FaceR)
        {
            turret.transform.localScale = new Vector3(turret.transform.localScale.x, -turret.transform.localScale.y, turret.transform.localScale.z);
            FaceR = false;
        }*/

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected void ShootAt(EnemyBase Enemy)
    {
        if (AttackTimer > 0) return;
        SoundManager.Instance.Play("Shoot");
        AttackTimer = AttackSpeed;
        GameObject tmp = Instantiate(projectile, turret.transform.position, Quaternion.identity);
        tmp.GetComponent<ProjectileBase>().currTarget = this.currTarget.gameObject;
        tmp.GetComponent<ProjectileBase>().damage = Damage;
    }

}
