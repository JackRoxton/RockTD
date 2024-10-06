using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject Player;
    public float GlobalTimer = 0;
    public float Money = 20;
    public float Life = 10;
    public bool inMenu = true;

    public void Play()
    {
        inMenu = false;
        EnemyManager.Instance.NextWave();
        SoundManager.Instance.Play("Click");
    }

    public bool Pay(int i)
    {
        if (i > Money)
            return false;
        Money -= i;
        return true;
    }

    public void LoseHp(int i)
    {
        Life -= i;
        SoundManager.Instance.Play("Damage");
        if (Life < 0)
        {
            GameOver();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        inMenu = true;
    }

    public void Win()
    {
        UIManager.Instance.Win();
        inMenu = true;
    }
}
