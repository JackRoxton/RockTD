using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public List<Transform> SpawnPoints;
    public List<Path> Path;
    public List<GameObject> EnemyPrefabs;
    float difficultyValue = 0;

    public List<Wave> Waves = new List<Wave>();
    Wave currentWave;
    public int WaveIndex = 0;
    List<int> enemyCounts = new List<int>();
    public int aliveEnemies = 0;

    float spawnTimer = 3;
    float currentTimer = 3;

    public float enemySpeedMod = 1f;
    public float enemyHealthMod = 1f;
    public int enemyNumberMod = 0;
    public int enemyHunterNumberMod = 0;

    public bool flag = true;

    private void Start()
    {
        flag = true;
        currentWave = Waves[0];
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
        enemyCounts.Add(0);
    }

    private void Update()
    {
        if (GameManager.Instance.inMenu) return;
        //if (flag) return;

        currentTimer -= Time.deltaTime;
        if(currentTimer <= 0)
        {
            if(!CheckCounts())
                SpawnEnemy();
            else if(aliveEnemies == 0)
            {
                if (flag) return;
                if(WaveIndex == 10)
                {
                    GameManager.Instance.Win();
                    return;
                }
                UIManager.Instance.ShowCards();
                flag = true;
            }
        }

    }

    public void NextWave()
    {
        currentWave = Waves[WaveIndex];
        enemyCounts[0] = currentWave.PickCount + enemyNumberMod;
        enemyCounts[1] = currentWave.HelmCount;
        enemyCounts[2] = currentWave.DynaCount;
        enemyCounts[3] = currentWave.ShovCount;
        enemyCounts[4] = currentWave.CrowbCount + enemyHunterNumberMod;
        enemyCounts[5] = currentWave.MiniBossCount;
        enemyCounts[6] = currentWave.BossCount;

        difficultyValue += 1;
        WaveIndex += 1;
        flag = false;
    }

    bool CheckCounts()
    {
        foreach(int i in enemyCounts)
        {
            if (i != 0) return false;
        }
        return true;
    }

    public void SpawnEnemy()
    {
        if (flag) return;
        int r = Random.Range(0, 3);
        int rand = 0;
        bool correctValue = false;
        while(!correctValue)
        {
            rand = Random.Range(0, 7);
            if (enemyCounts[rand] != 0)
            {
                correctValue = true;
            }
        }
        GameObject tmp = Instantiate(EnemyPrefabs[rand], SpawnPoints[r]);
        tmp.GetComponent<EnemyBase>().Path = Path[r];
        tmp.GetComponent<EnemyBase>().currPath = Path[r].list[0];
        tmp.GetComponent<EnemyBase>().MaxHp *= enemyHealthMod;
        tmp.GetComponent<EnemyBase>().CurrentHp *= enemyHealthMod;
        tmp.GetComponent<EnemyBase>().Speed *= enemySpeedMod;
        aliveEnemies++;
        enemyCounts[rand]--;

        currentTimer = spawnTimer - difficultyValue / 5;
    }
}
