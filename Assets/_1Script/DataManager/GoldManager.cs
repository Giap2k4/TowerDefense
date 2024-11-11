using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : GapiMonoBehaviour
{
    public static GoldManager instance;

    [SerializeField] protected Text txtGold;
    [SerializeField] protected Text txtDiamond;

    [SerializeField] public int gold;
    [SerializeField] public int diamond;

    protected override void Reset()
    {
        base.Reset();
        this.txtGold = GameObject.Find("Canvas/SafeArea/UITop/Gold/_Txt").GetComponent<Text>();
        this.txtDiamond = GameObject.Find("Canvas/SafeArea/UITop/Diamond/_Txt").GetComponent<Text>();
    }

    protected override void Awake()
    {
        base.Awake();
        GoldManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();

        this.gold = MainScore.instance.LoadInt("gold", 0);
        this.diamond = MainScore.instance.LoadInt("diamond", 0);

        this.txtGold.text = this.gold.ToString();
        this.txtDiamond.text = this.diamond.ToString();
    }

    public void AddGold(int amount)
    {
        this.gold += amount;
        MainScore.instance.SaveInt("gold", this.gold);
        UpdateGoldUI();
    }

    public void UseGold(int amount)
    {
        this.gold -= amount;
        MainScore.instance.SaveInt("gold", this.gold);
        UpdateGoldUI();
    }

    public void AddDiamonds(int amount)
    {
        this.diamond += amount;
        MainScore.instance.SaveInt("diamond", this.diamond);
        UpdateDiamondsUI();
    }

    public void UseDiamonds(int amount)
    {
        this.diamond -= amount;
        MainScore.instance.SaveInt("diamond", this.diamond);
        UpdateDiamondsUI();
    }

    public void UpdateGoldUI()
    {
        this.txtGold.text = MainScore.instance.LoadInt("gold", 0).ToString();
    }

    public void UpdateDiamondsUI()
    {
        this.txtDiamond.text = MainScore.instance.LoadInt("diamond", 0).ToString();
    }
}