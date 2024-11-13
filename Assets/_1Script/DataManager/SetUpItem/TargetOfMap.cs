using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetOfMap : GapiMonoBehaviour
{
    [SerializeField] protected RewardSO rewardSO;

    [SerializeField] protected Text txtGold1;
    [SerializeField] protected Text txtLevel1;
    [SerializeField] protected Text txtText1;

    [SerializeField] protected Text txtGold2;
    [SerializeField] protected Text txtLevel2;
    [SerializeField] protected Text txtText2;

    [SerializeField] protected Text txtGold3;
    [SerializeField] protected Text txtLevel3;
    [SerializeField] protected Text txtText3;

    [SerializeField] protected Text txtGold4;
    [SerializeField] protected Text txtLevel4;
    [SerializeField] protected Text txtText4;

    [SerializeField] protected string nameMap;
    [SerializeField] protected float levelOfMap;
    [SerializeField] protected float checkReward;

    protected override void Reset()
    {
        base.Reset();

        this.txtGold1 = transform.Find("Grid/Task_1/Panel/_TxtGold").GetComponent<Text>();
        this.txtLevel1 = transform.Find("Grid/Task_1/_TxtLevel").GetComponent<Text>();
        this.txtText1 = transform.Find("Grid/Task_1/_TxtText").GetComponent<Text>();

        this.txtGold2 = transform.Find("Grid/Task_2/Panel/_TxtGold").GetComponent<Text>();
        this.txtLevel2 = transform.Find("Grid/Task_2/_TxtLevel").GetComponent<Text>();
        this.txtText2 = transform.Find("Grid/Task_2/_TxtText").GetComponent<Text>();

        this.txtGold3 = transform.Find("Grid/Task_3/Panel/_TxtGold").GetComponent<Text>();
        this.txtLevel3 = transform.Find("Grid/Task_3/_TxtLevel").GetComponent<Text>();
        this.txtText3 = transform.Find("Grid/Task_3/_TxtText").GetComponent<Text>();

        this.txtGold4 = transform.Find("Grid/Task_4/Panel/_TxtGold").GetComponent<Text>();
        this.txtLevel4 = transform.Find("Grid/Task_4/_TxtLevel").GetComponent<Text>();
        this.txtText4 = transform.Find("Grid/Task_4/_TxtText").GetComponent<Text>();
    }

    protected void OnEnable()
    {

        this.nameMap = ScrollLevel.nameMap;
        this.rewardSO = Resources.Load<RewardSO>("Reward");

        this.levelOfMap = MainScore.instance.LoadFloat("map_" + this.nameMap, 0);
        this.checkReward = MainScore.instance.LoadFloat("reward_" + this.nameMap, 0);

        Text[] txtGold = { txtGold1, txtGold2, txtGold3, txtGold4 };

        for (int i = 0; i < txtGold.Length; i++)
        {
            txtGold[i].text = this.rewardSO.listReward[Convert.ToInt32(ScrollLevel.nameMap) - 1].list[i].ToString();
        }

        this.txtLevel1.text = this.levelOfMap.ToString() + "/15";
        this.txtLevel2.text = this.levelOfMap.ToString() + "/30";
        this.txtLevel3.text = this.levelOfMap.ToString() + "/45";
        this.txtLevel4.text = this.levelOfMap.ToString() + "/60";

        Text[] texts = { txtText1, txtText2, txtText3, txtText4 };

        for (int i = 0; i < texts.Length; i++)
        {
            if (i < checkReward)
            {
                texts[i].color = Color.green;
                texts[i].text = "Hoàn thành";
            }
            else
            {
                texts[i].color = Color.white;
                texts[i].text = "Chưa hoàn thành";
            }
        }

    }
}
