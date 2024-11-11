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
    [SerializeField] protected int levelOfMap;
    [SerializeField] protected int checkReward;

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
        this.rewardSO = Resources.Load<RewardSO>("Reward_" + this.nameMap);

        this.levelOfMap = MainScore.instance.LoadInt("map_" + this.nameMap, 0);
        this.checkReward = MainScore.instance.LoadInt("reward_" + this.nameMap, 0);

        this.txtGold1.text = this.rewardSO.listReward[0].ToString();
        this.txtGold2.text = this.rewardSO.listReward[1].ToString();
        this.txtGold3.text = this.rewardSO.listReward[2].ToString();
        this.txtGold4.text = this.rewardSO.listReward[3].ToString();

        this.txtLevel1.text = this.levelOfMap.ToString() + "/15";
        this.txtLevel2.text = this.levelOfMap.ToString() + "/30";
        this.txtLevel3.text = this.levelOfMap.ToString() + "/45";
        this.txtLevel4.text = this.levelOfMap.ToString() + "/60";

        if (this.checkReward == 4)
        {
            this.txtText1.color = Color.green;
            this.txtText1.text = "Hoàn thành";

            this.txtText2.color = Color.green;
            this.txtText2.text = "Hoàn thành";

            this.txtText3.color = Color.green;
            this.txtText3.text = "Hoàn thành";

            this.txtText4.color = Color.green;
            this.txtText4.text = "Hoàn thành";
        } 
        else if (this.checkReward == 3)
        {
            this.txtText1.color = Color.green;
            this.txtText1.text = "Hoàn thành";

            this.txtText2.color = Color.green;
            this.txtText2.text = "Hoàn thành";

            this.txtText3.color = Color.green;
            this.txtText3.text = "Hoàn thành";

            this.txtText4.color = Color.white;
            this.txtText4.text = "Chưa hoàn thành";
        }
        else if (this.checkReward == 2)
        {
            this.txtText1.color = Color.green;
            this.txtText1.text = "Hoàn thành";

            this.txtText2.color = Color.green;
            this.txtText2.text = "Hoàn thành";

            this.txtText3.color = Color.white;
            this.txtText3.text = "Chưa hoàn thành";

            this.txtText4.color = Color.white;
            this.txtText4.text = "Chưa hoàn thành";
        }
        else if (this.checkReward == 1)
        {
            this.txtText1.color = Color.green;
            this.txtText1.text = "Hoàn thành";

            this.txtText2.color = Color.white;
            this.txtText2.text = "Chưa hoàn thành";

            this.txtText3.color = Color.white;
            this.txtText3.text = "Chưa hoàn thành";

            this.txtText4.color = Color.white;
            this.txtText4.text = "Chưa hoàn thành";
        } 
        else
        {
            this.txtText1.color = Color.white;
            this.txtText1.text = "Chưa hoàn thành";

            this.txtText2.color = Color.white;
            this.txtText2.text = "Chưa hoàn thành";

            this.txtText3.color = Color.white;
            this.txtText3.text = "Chưa hoàn thành";

            this.txtText4.color = Color.white;
            this.txtText4.text = "Chưa hoàn thành";
        }

    }
}
