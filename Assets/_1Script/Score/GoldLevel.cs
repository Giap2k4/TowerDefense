using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldLevel : GapiMonoBehaviour
{
    public static GoldLevel instance;
    [SerializeField] public int goldLevel;
    [SerializeField] public Text txtGold;

    [SerializeField] public GameObject flash;
    [SerializeField] public GameObject fire;
    [SerializeField] public GameObject magic;
    [SerializeField] public GameObject ice;

    protected override void Awake()
    {
        base.Awake();
        GoldLevel.instance = this;
    }

    protected override void Reset()
    {
        base.Reset();

        this.flash = GameObject.Find("Canvas/UIBottom/CheckGold/Flash");
        this.fire = GameObject.Find("Canvas/UIBottom/CheckGold/Fire");
        this.magic = GameObject.Find("Canvas/UIBottom/CheckGold/Magic");
        this.ice = GameObject.Find("Canvas/UIBottom/CheckGold/Ice");
    }

    protected override void Start()
    {
        base.Start();

        this.goldLevel = 500;
        this.txtGold = GameObject.Find("Canvas/SafeArea/UITop/Gold/_Txt").GetComponent<Text>();

        this.txtGold.text = this.goldLevel.ToString();

    }

    public void GoldCollect(int gold)
    {
        this.goldLevel += gold;
        this.txtGold.text = this.goldLevel.ToString();

        this.CheckGold();

        if (TowerManager.instance.obj != null)
        TowerManager.instance.obj.GetComponent<ClickTower>().CheckGold();
    }

    public void GoldUse(int gold)
    {
        this.goldLevel -= gold;
        this.txtGold.text = this.goldLevel.ToString();

        this.CheckGold();

        if (TowerManager.instance.obj != null)
        TowerManager.instance.obj.GetComponent<ClickTower>().CheckGold();
    }

    public void CheckGold()
    {
        if (this.goldLevel >= 500)
        {
            this.flash.SetActive(false);
            this.fire.SetActive(false);
            this.magic.SetActive(false);
            this.ice.SetActive(false);
        }
        else if (this.goldLevel >= 300)
        {
            this.flash.SetActive(false);
            this.fire.SetActive(false);
            this.magic.SetActive(false);
            this.ice.SetActive(true);
        }
        else if (this.goldLevel >= 150)
        {
            this.flash.SetActive(false);
            this.fire.SetActive(false);
            this.magic.SetActive(true);
            this.ice.SetActive(true);
        }
        else if (this.goldLevel >= 100)
        {
            this.flash.SetActive(false);
            this.fire.SetActive(true);
            this.magic.SetActive(true);
            this.ice.SetActive(true);
        }
        else
        {
            this.flash.SetActive(true);
            this.fire.SetActive(true);
            this.magic.SetActive(true);
            this.ice.SetActive(true);
        }
    }

}
