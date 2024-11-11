using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGift : BaseButton
{
    [SerializeField] protected int gold;
    [SerializeField] protected int diamond;

    [SerializeField] protected Text txtGold;
    [SerializeField] protected Text txtDiamond;

    protected override void Reset()
    {
        base.Reset();
        this.gold = 2000;
        this.diamond = 200;

        this.txtGold = GameObject.Find("Canvas/Congratulate/GridItem/Item_1/_Txt").GetComponent<Text>();
        this.txtDiamond = GameObject.Find("Canvas/Congratulate/GridItem/Item_2/_Txt").GetComponent<Text>();
    }
    protected override void OnClick()
    {
        this.txtGold.text = gold.ToString();
        this.txtDiamond.text = diamond.ToString();
        MainScore.instance.SaveInt("giftNewbies", 1);

        GoldManager.instance.AddGold(gold);
        GoldManager.instance.AddDiamonds(diamond);
    }
}
