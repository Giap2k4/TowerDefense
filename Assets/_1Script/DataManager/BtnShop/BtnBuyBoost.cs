﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuyBoost : BaseButton
{
    [SerializeField] protected float quantityBoost;
    [SerializeField] protected Text txtMessage;

    protected override void Reset()
    {
        base.Reset();
        this.txtMessage = GameObject.Find("Canvas/Message/_TxtMess").GetComponent<Text>();
    }

    protected override void OnClick()
    {
        if (GoldManager.instance.diamond > 30)
        {
            this.quantityBoost = MainScore.instance.LoadFloat("quantityBoost", 0);
            this.quantityBoost++;
            MainScore.instance.SaveFloat("quantityBoost", this.quantityBoost);

            GoldManager.instance.UseDiamonds(30);

            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.white;
            this.txtMessage.text = "Mua thành công";

            return;
        }

        this.txtMessage.gameObject.SetActive(true);
        this.txtMessage.color = Color.red;
        this.txtMessage.text = "Không đủ kim cương";
        
    }
}
