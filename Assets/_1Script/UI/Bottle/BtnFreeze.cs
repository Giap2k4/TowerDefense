using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFreeze : BaseButton
{
    [SerializeField] protected GameObject freeze;
    [SerializeField] protected Freeze f;

    protected override void Reset()
    {
        base.Reset();
        this.freeze = GameObject.Find("Item").transform.Find("Prefab").transform.Find("Freeze").gameObject;
        this.f = this.freeze.GetComponent<Freeze>();
    }
    protected override void OnClick()
    {

        if (this.freeze.gameObject.activeSelf == false)
        {
            this.f.listEnemy.Clear();
            this.f.enemyVelocity.Clear();
            this.f.AddEnemy();
            if (this.f.checkListEmpty) return;

            this.freeze.SetActive(true);
            QuantityBottle.instance.FreezeUse(1);
        }

    }
}
