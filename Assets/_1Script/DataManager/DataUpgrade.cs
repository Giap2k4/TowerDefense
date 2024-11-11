using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataUpgrade : GapiMonoBehaviour
{
    public static DataUpgrade instance;

    [SerializeField] protected Text txtLevelBottle;
    [SerializeField] protected Text txtLevelBoost;
    [SerializeField] protected Text txtLevelFreeze;
    [SerializeField] protected Text txtLevelLightning;

    [SerializeField] protected int levelBottle;
    [SerializeField] protected int levelBoost;
    [SerializeField] protected int levelFreeze;
    [SerializeField] protected int levelLightning;

    [SerializeField] protected int maxLevelBottle;
    [SerializeField] protected int maxLevelBoost;
    [SerializeField] protected int maxLevelFreeze;
    [SerializeField] protected int maxLevelLightning;

    [SerializeField] protected float parameterBottle;
    [SerializeField] protected float parameterBoost;
    [SerializeField] protected float parameterFreeze;
    [SerializeField] protected float parameterLightning;

    [SerializeField] protected GameObject btnBottle;
    [SerializeField] protected GameObject textMaxLevelBottle;

    [SerializeField] protected GameObject btnBoost;
    [SerializeField] protected GameObject textMaxLevelBoost;

    [SerializeField] protected GameObject btnFreeze;
    [SerializeField] protected GameObject textMaxLevelFreeze;

    [SerializeField] protected GameObject btnLightning;
    [SerializeField] protected GameObject textMaxLevelLightning;

    [SerializeField] protected Text txtMessage;

    protected override void Reset()
    {
        base.Reset();

        this.txtLevelBottle = transform.Find("Grid/Inventory/_TxtLevel").GetComponent<Text>();
        this.txtLevelBoost = transform.Find("Grid/Boost/_TxtLevel").GetComponent<Text>();
        this.txtLevelFreeze = transform.Find("Grid/Freeze/_TxtLevel").GetComponent<Text>();
        this.txtLevelLightning = transform.Find("Grid/Lightning/_TxtLevel").GetComponent<Text>();

        this.btnBottle = transform.Find("Grid/Inventory/_Btn").gameObject;
        this.textMaxLevelBottle = transform.Find("Grid/Inventory/_TxtMaxLevel").gameObject;

        this.btnBoost = transform.Find("Grid/Boost/_Btn").gameObject;
        this.textMaxLevelBoost = transform.Find("Grid/Boost/_TxtMaxLevel").gameObject;

        this.btnFreeze = transform.Find("Grid/Freeze/_Btn").gameObject;
        this.textMaxLevelFreeze = transform.Find("Grid/Freeze/_TxtMaxLevel").gameObject;

        this.btnLightning = transform.Find("Grid/Lightning/_Btn").gameObject;
        this.textMaxLevelLightning = transform.Find("Grid/Lightning/_TxtMaxLevel").gameObject;

        this.txtMessage = GameObject.Find("Canvas/Message/_TxtMess").GetComponent<Text>();
    }

    protected override void Awake()
    {
        base.Awake();
        DataUpgrade.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.levelBottle = MainScore.instance.LoadInt("levelBottle", 0);
        this.levelBoost = MainScore.instance.LoadInt("levelBoost", 0);
        this.levelFreeze = MainScore.instance.LoadInt("levelFreeze", 0);
        this.levelLightning = MainScore.instance.LoadInt("levelLightning", 0);

        this.parameterBottle = MainScore.instance.LoadFloat("parameterBottle", 0);
        this.parameterBoost = MainScore.instance.LoadFloat("parameterBoost", 0);
        this.parameterFreeze = MainScore.instance.LoadFloat("parameterFreeze", 0);
        this.parameterLightning = MainScore.instance.LoadFloat("parameterLightning", 0);

        this.maxLevelBottle = MainScore.instance.LoadInt("maxLevelBottle", 6);
        this.maxLevelBoost = MainScore.instance.LoadInt("maxLevelBoost", 6);
        this.maxLevelFreeze = MainScore.instance.LoadInt("maxLevelFreeze", 6);
        this.maxLevelLightning = MainScore.instance.LoadInt("maxLevelLightning", 6);

        this.txtLevelBottle.text = this.levelBottle.ToString() + "/" + this.maxLevelBottle.ToString();
        this.txtLevelBoost.text = this.levelBoost.ToString() + "/" + this.maxLevelBoost.ToString();
        this.txtLevelFreeze.text = this.levelFreeze.ToString() + "/" + this.maxLevelFreeze.ToString();
        this.txtLevelLightning.text = this.levelLightning.ToString() + "/" + this.maxLevelLightning.ToString();

        // check ở đây nữa
        if (this.levelBottle >= this.maxLevelBottle)
        {
            this.btnBottle.SetActive(false);
            this.textMaxLevelBottle.SetActive(true);
        }

        if (this.levelBoost >= this.maxLevelBoost)
        {
            this.btnBoost.SetActive(false);
            this.textMaxLevelBoost.SetActive(true);
        }

        if (this.levelFreeze >= this.maxLevelFreeze)
        {
            this.btnFreeze.SetActive(false);
            this.textMaxLevelFreeze.SetActive(true);
        }

        if (this.levelLightning >= this.maxLevelLightning)
        {
            this.btnLightning.SetActive(false);
            this.textMaxLevelLightning.SetActive(true);

        }
    }

    public void UpgradeBottle()
    {
        if (GoldManager.instance.gold > 1000)
        {
            
            this.levelBottle++;
            this.parameterBottle++;

            GoldManager.instance.UseGold(1000);

            MainScore.instance.SaveInt("levelBottle", this.levelBottle);
            MainScore.instance.SaveFloat("parameterBottle", this.parameterBottle);

            this.txtLevelBottle.text = this.levelBottle.ToString() + "/" + this.maxLevelBottle.ToString();

            if (this.levelBottle >= this.maxLevelBottle)
            {
                this.btnBottle.SetActive(false);
                this.textMaxLevelBottle.SetActive(true);
            }
        } 
        
        else
        {
            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.red;
            this.txtMessage.text = "Không đủ vàng!";
        }
    }

    public void UpgradeBoost()
    {
        if (GoldManager.instance.gold > 300)
        {
            this.levelBoost++;
            this.parameterBoost += 0.5f;

            GoldManager.instance.UseGold(300);

            MainScore.instance.SaveInt("levelBoost", this.levelBoost);
            MainScore.instance.SaveFloat("parameterBoost", this.parameterBoost);

            this.txtLevelBoost.text = this.levelBoost.ToString() + "/" + this.maxLevelBoost.ToString();

            if (this.levelBoost >= this.maxLevelBoost)
            {
                this.btnBoost.SetActive(false);
                this.textMaxLevelBoost.SetActive(true);
            }
        }

        else
        {
            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.red;
            this.txtMessage.text = "Không đủ vàng!";
        }
    }

    public void UpgradeFreeze()
    {
        if (GoldManager.instance.gold > 300)
        {

            this.levelFreeze++;
            this.parameterFreeze += 0.5f;

            GoldManager.instance.UseGold(300);

            MainScore.instance.SaveInt("levelFreeze", this.levelFreeze);
            MainScore.instance.SaveFloat("parameterFreeze", this.parameterFreeze);

            this.txtLevelFreeze.text = this.levelFreeze.ToString() + "/" + this.maxLevelFreeze.ToString();

            if (this.levelFreeze >= this.maxLevelFreeze)
            {
                this.btnFreeze.SetActive(false);
                this.textMaxLevelFreeze.SetActive(true);
            }
        }

        else
        {
            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.red;
            this.txtMessage.text = "Không đủ vàng!";
        }
    }

    public void UpgradeLightning() 
    {
        if (GoldManager.instance.gold > 300)
        {

            this.levelLightning++;
            this.parameterLightning += 500f;

            GoldManager.instance.UseGold(300);

            MainScore.instance.SaveInt("levelLightning", this.levelLightning);
            MainScore.instance.SaveFloat("parameterLightning", this.parameterLightning);

            this.txtLevelLightning.text = this.levelLightning.ToString() + "/" + this.maxLevelLightning.ToString();

            if (this.levelLightning >= this.maxLevelLightning)
            {
                this.btnLightning.SetActive(false);
                this.textMaxLevelLightning.SetActive(true);

            }
        }

        else
        {
            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.red;
            this.txtMessage.text = "Không đủ vàng!";
        }
    }
}
