using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBoost : BaseButton
{
    [SerializeField] protected GameObject boost;
    [SerializeField] protected Boost b;

    protected override void Reset()
    {
        base.Reset();
        this.boost = GameObject.Find("Item").transform.Find("Prefab").transform.Find("Boost").gameObject;
        this.b = this.boost.GetComponent<Boost>();
    }
    protected override void OnClick()
    {
        if (this.boost.gameObject.activeSelf == false)
        {
            this.b.AddTower();
            if (this.b.checkListEmpty) return;

            this.boost.SetActive(true);
            QuantityBottle.instance.BoostUse(1);
        }

    }
}
