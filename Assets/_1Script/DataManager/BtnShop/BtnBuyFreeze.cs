using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuyFreeze : BaseButton
{
    [SerializeField] protected int quantityFreeze;
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
            this.quantityFreeze = MainScore.instance.LoadInt("quantityFreeze", 0);
            this.quantityFreeze++;
            MainScore.instance.SaveInt("quantityFreeze", this.quantityFreeze);

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
