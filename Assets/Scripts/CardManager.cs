using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : Singleton<CardManager>
{
    public List<TowerBase> TowerBaseList;
    public List<TowerSpot> TowerSpotList;

    public List<string> PositiveTexts = new List<string>();
    public List<string> NegativeTexts = new List<string>();

    int currenti, currenti2;
    int currentj, currentj2;

    public void CardEffect(TMP_Text ptxt, TMP_Text ntxt, TMP_Text ptxt2, TMP_Text ntxt2)
    {
        int i = Random.Range(0, PositiveTexts.Count);
        ptxt.text = PositiveTexts[i];
        currenti = i;

        int j = Random.Range(0, NegativeTexts.Count);
        ntxt.text = NegativeTexts[j];
        currentj = j;

        int i2 = Random.Range(0, PositiveTexts.Count);
        ptxt2.text = PositiveTexts[i2];
        currenti2 = i2;

        int j2 = Random.Range(0, NegativeTexts.Count);
        ntxt2.text = NegativeTexts[j2];
        currentj2 = j2;
    }

    public void Effects()
    {
        switch(currenti)
        {
            case 0:
                BoostAttack();
                break;
            case 1:
                BoostAttackSpeed();
                break;
            case 2:
                BoostRange();
                break;
            case 3:
                BoostBite();
                break;
            case 4:
                BoostSmash();
                break;
        }

        switch (currentj)
        {
            case 0:
                BoostEnemySpeed();
                break;
            case 1:
                BoostEnemyHealth();
                break;
            case 2:
                BoostEnemyNumber();
                break;
            case 3:
                BoostEnemyHunterNumber();
                break;
            case 4:
                LoseHealth();
                break;
        }
    }
    public void Effects2()
    {
        switch (currenti2)
        {
            case 0:
                BoostAttack();
                break;
            case 1:
                BoostAttackSpeed();
                break;
            case 2:
                BoostRange();
                break;
            case 3:
                BoostBite();
                break;
            case 4:
                BoostSmash();
                break;
        }

        switch (currentj2)
        {
            case 0:
                BoostEnemySpeed();
                break;
            case 1:
                BoostEnemyHealth();
                break;
            case 2:
                BoostEnemyNumber();
                break;
            case 3:
                BoostEnemyHunterNumber();
                break;
            case 4:
                LoseHealth();
                break;
        }
    }

    private void BoostAttack()
    {
        foreach(TowerBase t in TowerBaseList)
        {
            t.Damage *= 1.1f;
        }
        foreach (TowerSpot t in TowerSpotList)
        {
            t.damagemod *= 1.1f;
        }
    }

    private void BoostAttackSpeed()
    {
        foreach (TowerBase t in TowerBaseList)
        {
            t.AttackSpeed /= 1.1f;
        }
        foreach (TowerSpot t in TowerSpotList)
        {
            t.attackspeedmod *= 1.1f;
        }
    }

    private void BoostRange()
    {
        foreach (TowerBase t in TowerBaseList)
        {
            t.Range *= 1.2f;
            t.RangeChange();
        }
        foreach (TowerSpot t in TowerSpotList)
        {
            t.rangemod *= 1.2f;
        }
    }

    private void BoostBite()
    {
        GameManager.Instance.Player.GetComponent<Character>().BiteCD /= 1.2f;
    }

    private void BoostSmash()
    {
        GameManager.Instance.Player.GetComponent<Character>().SmashCD /= 1.2f;
    }

    private void BoostEnemySpeed()
    {
        EnemyManager.Instance.enemySpeedMod *= 1.1f;
    }

    private void BoostEnemyHealth()
    {
        EnemyManager.Instance.enemyHealthMod *= 1.1f;
    }

    private void BoostEnemyNumber()
    {
        EnemyManager.Instance.enemyNumberMod += 1;
    }

    private void BoostEnemyHunterNumber()
    {
        EnemyManager.Instance.enemyHunterNumberMod += 1;
    }

    private void LoseHealth()
    {
        GameManager.Instance.LoseHp(1);
    }

}
