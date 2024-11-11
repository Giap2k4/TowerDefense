using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSetUpItem : GapiMonoBehaviour
{
    public static DataSetUpItem instance;

    // Dữ liệu trong 1 trận
    public static int quantityBoost;
    public static int quantityFreeze;
    public static int quantityLightning;

    [SerializeField] protected Text txtQuantityBoost;
    [SerializeField] protected Text txtQuantityFreeze;
    [SerializeField] protected Text txtQuantityLightning; 
    //

    [SerializeField] protected int sumBottle = 0;
    [SerializeField] protected int sumBoost = 0;
    [SerializeField] protected int sumFreeze = 0;
    [SerializeField] protected int sumLightning = 0;
    [SerializeField] protected float maxSumBottle;

    // Dữ liệu trên data
    [SerializeField] protected int quantityDataBoost;
    [SerializeField] protected int quantityDataFreeze;
    [SerializeField] protected int quantityDataLightning;

    [SerializeField] protected int levelBoost;
    [SerializeField] protected int levelFreeze;
    [SerializeField] protected int levelLightning;

    [SerializeField] protected Text txtQuantityDataBoost;
    [SerializeField] protected Text txtQuantityDataFreeze;
    [SerializeField] protected Text txtQuantityDataLightning;

    [SerializeField] protected Text txtLevelBoost;
    [SerializeField] protected Text txtLevelFreeze;
    [SerializeField] protected Text txtLevelLightning;
    //

    [SerializeField] protected Text txtSumBottle;

    [SerializeField] protected Text Message;

    protected override void Reset()
    {
        base.Reset();

        quantityBoost = 0;
        quantityFreeze = 0;
        quantityLightning = 0;

        this.txtQuantityBoost = transform.Find("Item/Grid1/ImgBoost/_Txt").GetComponent<Text>();
        this.txtQuantityFreeze = transform.Find("Item/Grid1/ImgFreeze/_Txt").GetComponent<Text>();
        this.txtQuantityLightning = transform.Find("Item/Grid1/ImgLightning/_Txt").GetComponent<Text>();

        this.txtQuantityDataBoost = transform.Find("Item/Grid/Boost/_Txt").GetComponent<Text>();
        this.txtQuantityDataFreeze = transform.Find("Item/Grid/Freeze/_Txt").GetComponent<Text>();
        this.txtQuantityDataLightning = transform.Find("Item/Grid/Lightning/_Txt").GetComponent<Text>();

        this.txtLevelBoost = transform.Find("Item/Grid/Boost/BtnBoost/_TxtLevel").GetComponent<Text>();
        this.txtLevelFreeze = transform.Find("Item/Grid/Freeze/BtnFreeze/_TxtLevel").GetComponent<Text>();
        this.txtLevelLightning = transform.Find("Item/Grid/Lightning/BtnLightning/_TxtLevel").GetComponent<Text>();

        this.txtSumBottle = transform.Find("Item/_Txt").GetComponent<Text>();

        this.Message = GameObject.Find("Canvas/Message/_TxtMess").GetComponent<Text>();
    }

    protected override void Awake()
    {
        base.Awake();
        DataSetUpItem.instance = this;
    }

    protected void OnEnable()
    {
        quantityBoost = 0;
        quantityFreeze = 0;
        quantityLightning = 0;

        this.sumBottle = 0;
        this.sumBoost = 0;
        this.sumFreeze = 0;
        this.sumLightning = 0;

        this.maxSumBottle = MainScore.instance.LoadFloat("parameterBottle", 0);

        this.quantityDataBoost = MainScore.instance.LoadInt("quantityBoost", 0);
        this.quantityDataFreeze = MainScore.instance.LoadInt("quantityFreeze", 0);
        this.quantityDataLightning = MainScore.instance.LoadInt("quantityLightning", 0);

        this.levelBoost = MainScore.instance.LoadInt("levelBoost", 0);
        this.levelFreeze = MainScore.instance.LoadInt("levelFreeze", 0);
        this.levelLightning = MainScore.instance.LoadInt("levelLightning", 0);

        this.txtQuantityDataBoost.text = this.quantityDataBoost.ToString();
        this.txtQuantityDataFreeze.text = this.quantityDataFreeze.ToString();
        this.txtQuantityDataLightning.text = this.quantityDataLightning.ToString();

        this.txtLevelBoost.text = this.levelBoost.ToString();
        this.txtLevelFreeze.text = this.levelFreeze.ToString();
        this.txtLevelLightning.text = this.levelLightning.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle.ToString();

        this.txtQuantityBoost.text = "x0";
        this.txtQuantityFreeze.text = "x0";
        this.txtQuantityLightning.text = "x0";

    }

    public void OnEnableCountBottle()
    {
        quantityBoost = 0;
        quantityFreeze = 0;
        quantityLightning = 0;
    }

    public void AddBoost(int count)
    {
        if (this.sumBottle >= this.maxSumBottle || this.sumBoost == this.quantityDataBoost)
        {
            this.Message.gameObject.SetActive(true);

            this.Message.color = Color.red;
            this.Message.text = "Không đủ số lượng";
            return;
        }

        this.sumBottle++;
        this.sumBoost++;

        quantityBoost += count;
        this.txtQuantityBoost.text = "x" + quantityBoost.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle;
    }

    public void AddFreeze(int count)
    {
        if (this.sumBottle >= this.maxSumBottle || this.sumFreeze == this.quantityDataFreeze)
        {
            this.Message.gameObject.SetActive(true);

            this.Message.color = Color.red;
            this.Message.text = "Không đủ số lượng";
            return;
        }

        this.sumBottle++;
        this.sumFreeze++;

        quantityFreeze += count;
        this.txtQuantityFreeze.text = "x" + quantityFreeze.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle;
    }

    public void AddLightning(int count)
    {
        if (this.sumBottle >= this.maxSumBottle || this.sumLightning == this.quantityDataLightning)
        {
            this.Message.gameObject.SetActive(true);

            this.Message.color = Color.red;
            this.Message.text = "Không đủ số lượng";
            return;
        }

        this.sumBottle++;
        this.sumLightning++;

        quantityLightning += count;
        this.txtQuantityLightning.text = "x" + quantityLightning.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle;
    }

    public void ClearBoost(int count)
    {
        if (quantityBoost <= 0) return;
        if (this.sumBottle <= 0) return;

        this.sumBottle--;
        this.sumBoost--;

        quantityBoost -= count;
        this.txtQuantityBoost.text = "x" + quantityBoost.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle;
    }

    public void ClearFreeze(int count)
    {
        if (quantityFreeze <= 0) return;
        if (this.sumBottle <= 0) return;

        this.sumBottle--;
        this.sumFreeze--;

        quantityFreeze -= count;
        this.txtQuantityFreeze.text = "x" + quantityFreeze.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle;
    }

    public void ClearLightning(int count)
    {
        if (quantityLightning <= 0) return;
        if (this.sumBottle <= 0) return;

        this.sumBottle--;
        this.sumLightning--;

        quantityLightning -= count;
        this.txtQuantityLightning.text = "x" + quantityLightning.ToString();

        this.txtSumBottle.text = this.sumBottle.ToString() + " / " + this.maxSumBottle;
    }
}
