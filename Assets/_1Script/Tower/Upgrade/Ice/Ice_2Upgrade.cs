using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_2Upgrade : UpgradeTower
{
    protected override void Reset()
    {
        base.Reset();

        damage = 0;
        this.range = 0.05f;
        this.timeAttack = 0.1f;
        this.damageIncrease = 0;

        this.goldUpLevel = 500;
        this.goldUpgrade = 0;
        this.goldSell = 400;

        this.goldAfterUpgrade = 50;
    }

    protected void OnEnable()
    {
        this.range = 0.05f;
        this.goldUpLevel = 500;
        this.goldUpgrade = 0;
        this.goldSell = 400;
    }

    public override float GetDamage()
    {
        return damage;
    }

    public override void SetDamage()
    {

    }
}
