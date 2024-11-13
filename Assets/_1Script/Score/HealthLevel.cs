using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLevel : GapiMonoBehaviour
{
    public static HealthLevel instance;
    [SerializeField] protected Text txtHealth;
    [SerializeField] protected int healthLevel = 20;

    [SerializeField] protected float checkRewardFirst;
    [SerializeField] protected float checkRewardLast;

    [SerializeField] protected GameObject successGame;
    [SerializeField] protected GameObject reward;
    [SerializeField] protected GameObject noReward;

    [SerializeField] protected Text txtGold;
    [SerializeField] protected Text txtDiamond;
    [SerializeField] protected int gold;
    [SerializeField] protected int diamond;

    [SerializeField] protected Text txtNameMap;
    [SerializeField] protected Text txtLevelMap;

    [SerializeField] protected float goldFirst;
    [SerializeField] protected float diamondFirst;

    [SerializeField] protected RewardSO rewardSO;

    protected override void Reset()
    {
        base.Reset();

        this.successGame = GameObject.Find("Canvas/SuccessGame");
        this.reward = GameObject.Find("Canvas/SuccessGame/GridItem");
        this.noReward = GameObject.Find("Canvas/SuccessGame/NoReward");

        this.txtGold = GameObject.Find("Canvas/SuccessGame/GridItem/Item_1/_Txt").GetComponent<Text>();
        this.txtDiamond = GameObject.Find("Canvas/SuccessGame/GridItem/Item_2/_Txt").GetComponent<Text>();

        this.txtNameMap = GameObject.Find("Canvas/SuccessGame/_TxtNameMap").GetComponent<Text>();
        this.txtLevelMap = GameObject.Find("Canvas/SuccessGame/_TxtLevel").GetComponent<Text>();
    }

    protected override void Awake()
    {
        base.Awake();
        HealthLevel.instance = this;

        this.rewardSO = Resources.Load<RewardSO>("Reward");

        this.goldFirst = MainScore.instance.LoadFloat("gold", 0);
        this.diamondFirst = MainScore.instance.LoadFloat("diamond", 0);
    }

    protected override void Start()
    {
        base.Start();

        this.txtHealth = GameObject.Find("Canvas/SafeArea/UITop/Health/_Txt").GetComponent<Text>();
        this.txtHealth.text = healthLevel.ToString();
    }

    protected void OnApplicationQuit()
    {
        this.CheckReward();
    }

    public void CheckHealth(int health)
    {
        this.healthLevel -= health;
        this.txtHealth.text = healthLevel.ToString();

        this.IsDead();
    }

    public void IsDead()
    {
        if (this.healthLevel <= 0)
        {
            Time.timeScale = 0;

            this.successGame.SetActive(true);
            this.CheckReward();

            if (DataSetUpItem.instance == null)
            {
                Debug.Log("Null ở datasetupItem");
                return;
            }
            DataSetUpItem.instance.OnEnableCountBottle();
        }
    }

    public void CheckReward()
    {
        this.checkRewardFirst = EnemyManager.instance.checkReward;
        this.checkRewardLast = MainScore.instance.LoadFloat("reward_" + ScrollLevel.nameMap, 0);
        MainScore.instance.SaveFloat("reward_" + ScrollLevel.nameMap, this.checkRewardLast);

        if (this.checkRewardFirst >= this.checkRewardLast)
        {
            this.noReward.SetActive(true);
        }

        else
        {
            // Nhận phần thưởng
            this.reward.SetActive(true);

            for (int i = 0; i < this.rewardSO.listReward[Convert.ToInt32(ScrollLevel.nameMap) - 1].list.Count; i++)
            {
                if (i >= this.checkRewardFirst && i < this.checkRewardLast)
                {
                    if (i == 0 || i == 2)
                    {
                        this.gold += this.rewardSO.listReward[Convert.ToInt32(ScrollLevel.nameMap)].list[i];
                    }
                    else
                    {
                        this.diamond += this.rewardSO.listReward[Convert.ToInt32(ScrollLevel.nameMap)].list[i];
                    }
                }
            }

            this.txtGold.text = this.gold.ToString();
            this.txtDiamond.text = this.diamond.ToString();

            this.goldFirst += this.gold;
            this.diamondFirst += this.diamond;

            MainScore.instance.SaveFloat("gold", this.goldFirst);
            MainScore.instance.SaveFloat("diamond", this.diamondFirst);
        }

        this.txtNameMap.text = "Bản đồ " + ScrollLevel.nameMap;
        this.txtLevelMap.text = "Vượt đến màn " + (EnemyManager.instance.level - 1);
    }

}
