using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public float Speed;
    public float MaxHp;
    public float CurrentHp;
    public float Value;
    public Path Path;
    protected int PathId = 0;
    public Transform currPath;

    public Image LifeBar;

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity *= 0.9f;
    }

    public void TakeDamage(float damage)
    {
        if(this.GetComponent<Dynamite>()) { this.GetComponent<Dynamite>().TakeDamaged(damage); return; }
        CurrentHp -= damage;
        if(CurrentHp <= 0)
        {
            SoundManager.Instance.Play("Die");
            GameManager.Instance.Money += Value;
            Destroy(this.gameObject);
        }
        LifeBar.fillAmount = CurrentHp/MaxHp;
    }

}
