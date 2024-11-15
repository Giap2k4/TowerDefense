﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : Spawns
{
    public static EnemyManager instance;

    [SerializeField] protected Vector3 pos;
    [SerializeField] protected Quaternion rot = new Quaternion(0, 0, 0, 0);
    [SerializeField] protected bool canSpawn = true;
    [SerializeField] protected bool isSpawning = true;
    [SerializeField] public int level;

    [SerializeField] protected int spawnRound = 1;
    [SerializeField] protected int resetCount = 1;
    [SerializeField] protected int spawnCountList = 1; // dựa vào resetCount
    [SerializeField] protected int enemyCount = 1; // dựa vào resetCount

    protected int SmallCount = 5;
    protected int GiantCount = 5;
    protected int WitchCount = 6;
    protected int WizardCount = 6;

    [SerializeField] protected PosSpawnEnemy posSpawnEnemy;
    [SerializeField] public float checkReward;
    [SerializeField] protected float checkLevelFirst; 

    [SerializeField] public bool nextLevel = false;
    [SerializeField] public GameObject btnNextLevel;
    [SerializeField] protected Text txtLevel;

    [SerializeField] public bool checkPause = false;
    [SerializeField] public bool checkPauseTrue = false;
    [SerializeField] public int currentStep = 0;
    [SerializeField] protected float timeCheckDelay = 0;

    [SerializeField] public int goldNextLevel = 50;

    [SerializeField] protected ListSpawnEnemyLevelSO listSpawnEnemyLevelSO;

    protected override void Reset()
    {
        base.Reset();

        this.level = 1;
        this.btnNextLevel = GameObject.Find("NextLevel");

        this.txtLevel = GameObject.Find("Canvas").transform.Find("UIBottom").transform.Find("_TxtLevel").GetComponent<Text>();
        this.posSpawnEnemy = Resources.Load<PosSpawnEnemy>("PosSpawn");

        listSpawnEnemyLevelSO = Resources.Load<ListSpawnEnemyLevelSO>("ListSpawnEnemy");
    }

    protected override void Awake()
    {
        base.Awake();
        EnemyManager.instance = this;

        //DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();

        this.pos = this.posSpawnEnemy.listPos[Convert.ToInt32(ScrollLevel.nameMap) - 1];
        this.checkReward = MainScore.instance.LoadFloat("reward_" + ScrollLevel.nameMap, 0);
        this.checkLevelFirst = MainScore.instance.LoadFloat("map_" + ScrollLevel.nameMap, 0);
    }
    private void Update()
    {
        this.SpawnEnemy();
    }

    protected void SpawnEnemy()
    {
        if (!this.canSpawn || !this.isSpawning || !this.nextLevel) return;

        this.txtLevel.text = Mathf.Ceil(this.level).ToString();

        switch (this.spawnRound)
        {

            case 1:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(0), 0.8f));
                break;

            case 2:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(1), 0.8f));
                break;

            case 3:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(2), 0.8f));
                break;

            case 4:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(3), 0.8f));
                break;

            case 5:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(4), 0.8f));
                break;

            case 6:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(5), 0.8f));
                break;

            case 7:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(1), 0.8f));
                break;

            case 8:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(6), 0.8f));
                break;

            case 9:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(4), 0.8f));
                break;

            case 10:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(2), 0.8f));
                break;

            case 11:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(7), 0.8f));
                break;

            case 12:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(9), 0.8f));
                break;

            case 13:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(8), 0.8f));
                break;

            case 14:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(10), 0.8f));
                break;

            case 15:
                StartCoroutine(SpawnList1(listSpawnEnemyLevelSO.List(12), 0.8f));
                break;

            default:
                this.spawnRound = 1;
                this.resetCount += 1;

                break;
        }
    }

    IEnumerator SpawnList1(List<int> list, float delay)
    {
        if (this.level > this.checkLevelFirst)
        {
            MainScore.instance.SaveFloat("map_" + ScrollLevel.nameMap, this.level);
        }
        
        if (this.level / 15 > this.checkReward)
        {
            MainScore.instance.SaveFloat("reward_" + ScrollLevel.nameMap, this.level / 15);
        }

        for (int i = 0; i < this.resetCount; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                switch (list[j])
                {

                    case 1:
                        yield return StartCoroutine(SpawnTypeEnemies(this.SmallCount, delay, list[j], pos, rot));
                        break;

                    case 2:
                        yield return StartCoroutine(SpawnTypeEnemies(this.GiantCount, delay, list[j], pos, rot));
                        break;

                    case 3:
                        yield return StartCoroutine(SpawnTypeEnemies(this.WizardCount, delay, list[j], pos, rot));
                        break;

                    case 4:
                        yield return StartCoroutine(SpawnTypeEnemies(this.WitchCount, delay, list[j], pos, rot));
                        break;

                }
            }
        }


        this.spawnRound++;
        this.level++;

        this.btnNextLevel.SetActive(true);
        this.canSpawn = true;
        this.nextLevel = false;
    }

    IEnumerator SpawnTypeEnemies(int enemyCount, float delay, int enemyIndex, Vector3 pos, Quaternion rot)
    {
        for (int x = 0; x < (enemyCount + this.resetCount); x++)
        {
            this.isSpawning = false;

            float elapsedTime = 0f;

            while (elapsedTime < delay)
            {
                if (this.checkPause)
                {
                    yield return null; 
                    continue; 
                }

                elapsedTime += Time.deltaTime; 
                yield return null; 
            }

            this.Spawn(this.GetNameEnemy(enemyIndex), pos, rot);
        }


        this.canSpawn = false;
        this.isSpawning = true;
        yield return new WaitForSeconds(delay);
    }

    protected string GetNameEnemy(int i)
    {
        if (i == 1) return "Small";
        if (i == 2) return "Giant";
        if (i == 3) return "Wizard";
        if (i == 4) return "Witch";

        return null;
    }

}
