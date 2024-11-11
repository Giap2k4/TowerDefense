using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLightning : BaseButton
{
    [SerializeField] protected GameObject lightning;
    [SerializeField] protected Lightning l;

    protected override void Reset()
    {
        base.Reset();
        this.lightning = GameObject.Find("Item").transform.Find("Prefab").transform.Find("Lightning").gameObject;
        this.l = this.lightning.GetComponent<Lightning>();
    }
    protected override void OnClick()
    {

        if (this.lightning.activeSelf == false)
        {
            this.l.listEnemy.Clear();
            this.l.AddEnemy();
            if (this.l.checkListEmpty) return;

            this.lightning.SetActive(true);
            QuantityBottle.instance.LightningUse(1);
        }
    }
}
