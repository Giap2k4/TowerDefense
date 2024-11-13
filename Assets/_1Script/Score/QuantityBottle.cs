using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityBottle : GapiMonoBehaviour
{
    public static QuantityBottle instance;

    [SerializeField] public int quantityBoost;
    [SerializeField] public int quantityFreeze;
    [SerializeField] public int quantityLightning;

    [SerializeField] public float quantityDataBoost;
    [SerializeField] public float quantityDataFreeze;
    [SerializeField] public float quantityDataLightning;

    [SerializeField] protected Text txtBoost; 
    [SerializeField] protected Text txtFreeze; 
    [SerializeField] protected Text txtLightning;

    [SerializeField] protected Text txtLevelBoost;
    [SerializeField] protected Text txtLevelFreeze;
    [SerializeField] protected Text txtLevelLightning;

    [SerializeField] protected GameObject checkBoost;
    [SerializeField] protected GameObject checkFreeze;
    [SerializeField] protected GameObject checkLightning;

    protected override void Reset()
    {
        base.Reset();

        this.txtBoost = GameObject.Find("Canvas/UIBottom/GridBottle/Boost/_TxtQuantity").GetComponent<Text>();
        this.txtFreeze = GameObject.Find("Canvas/UIBottom/GridBottle/Freeze/_TxtQuantity").GetComponent<Text>();
        this.txtLightning = GameObject.Find("Canvas/UIBottom/GridBottle/Lightning/_TxtQuantity").GetComponent<Text>();

        this.txtLevelBoost = GameObject.Find("Canvas/UIBottom/GridBottle/Boost/Level/_TxtLevel").GetComponent<Text>();
        this.txtLevelFreeze = GameObject.Find("Canvas/UIBottom/GridBottle/Freeze/Level/_TxtLevel").GetComponent<Text>();
        this.txtLevelLightning = GameObject.Find("Canvas/UIBottom/GridBottle/Lightning/Level/_TxtLevel").GetComponent<Text>();

        this.checkBoost = GameObject.Find("Canvas/UIBottom/CheckBottle/Boost");
        this.checkFreeze = GameObject.Find("Canvas/UIBottom/CheckBottle/Freeze");
        this.checkLightning = GameObject.Find("Canvas/UIBottom/CheckBottle/Lightning");
    }

    protected override void Awake()
    {
        base.Awake();
        QuantityBottle.instance = this;
    }

    protected override void Start()
    {
        base.Start();

        this.quantityBoost = DataSetUpItem.quantityBoost;
        this.quantityFreeze = DataSetUpItem.quantityFreeze;
        this.quantityLightning = DataSetUpItem.quantityLightning;

        this.quantityDataBoost = MainScore.instance.LoadFloat("quantityBoost", 0);
        this.quantityDataFreeze = MainScore.instance.LoadFloat("quantityFreeze", 0);
        this.quantityDataLightning = MainScore.instance.LoadFloat("quantityLightning", 0);

        txtBoost.text = "x" + this.quantityBoost.ToString();
        txtFreeze.text = "x" + this.quantityFreeze.ToString();
        txtLightning.text = "x" + this.quantityLightning.ToString();

        txtLevelBoost.text = MainScore.instance.LoadFloat("levelBoost", 1).ToString();
        txtLevelFreeze.text = MainScore.instance.LoadFloat("levelFreeze", 1).ToString();
        txtLevelLightning.text = MainScore.instance.LoadFloat("levelLightning", 1).ToString();

        if (this.quantityBoost <= 0)
        {
            this.checkBoost.SetActive(true);
        }

        if (this.quantityFreeze <= 0)
        {
            this.checkFreeze.SetActive(true);
        }

        if (this.quantityLightning <= 0)
        {
            this.checkLightning.SetActive(true);
        }
    }

    public void BoostUse(int count)
    {
        this.quantityBoost -= count;
        this.quantityDataBoost -= count;

        MainScore.instance.SaveFloat("quantityBoost", this.quantityDataBoost);

        txtBoost.text = "x" + this.quantityBoost.ToString();

        if (this.quantityBoost <= 0)
        {
            this.checkBoost.SetActive(true);
            return;
        }
    }

    public void FreezeUse(int count)
    {
        this.quantityFreeze -= count;
        this.quantityDataFreeze -= count;

        MainScore.instance.SaveFloat("quantityFreeze", this.quantityDataFreeze);

        txtFreeze.text = "x" + this.quantityFreeze.ToString();

        if (this.quantityFreeze <= 0)
        {
            this.checkFreeze.SetActive(true);
            return;
        }
    }

    public void LightningUse(int count)
    {
        this.quantityLightning -= count;
        this.quantityDataLightning -= count;

        MainScore.instance.SaveFloat("quantityLightning", this.quantityDataLightning);

        txtLightning.text = "x" + this.quantityLightning.ToString();

        if (this.quantityLightning <= 0)
        {
            this.checkLightning.SetActive(true);
            return;
        }
    }
}
