using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuyLightning : BaseButton
{
    [SerializeField] protected int quantityLightning;
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
            this.quantityLightning = MainScore.instance.LoadInt("quantityLightning", 0);
            this.quantityLightning++;
            MainScore.instance.SaveInt("quantityLightning", this.quantityLightning);

            GoldManager.instance.UseDiamonds(30);

            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.white;
            this.txtMessage.text = "Mua thành công";
        }
        else
        {
            this.txtMessage.gameObject.SetActive(true);
            this.txtMessage.color = Color.red;
            this.txtMessage.text = "Không đủ kim cương";
        }
    }
}
