using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckGiftNewbies : GapiMonoBehaviour
{
    [SerializeField] protected GameObject gift;
    [SerializeField] protected int check;

    protected override void Reset()
    {
        base.Reset();
        this.gift = GameObject.Find("Canvas/Gift");
    }

    protected override void Start()
    {
        base.Start();
        this.check = MainScore.instance.LoadInt("giftNewbies", 0);
        if (this.check == 0)
        {
            this.gift.SetActive(true);
        } 
        else this.gift.SetActive(false);
    }
}
