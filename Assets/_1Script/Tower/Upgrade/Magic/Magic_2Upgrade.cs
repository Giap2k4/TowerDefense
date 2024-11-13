using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_2Upgrade : UpgradeTower
{
    protected override void Reset()
    {
        base.Reset();

        damage = 20;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 5f;

        this.goldUpLevel = 400;
        this.goldUpgrade = 0;
        this.goldSell = 500;

        this.goldAfterUpgrade = 75;
    }

    protected void OnEnable()
    {
        damage = 20;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 5f;

        this.goldUpLevel = 400;
        this.goldUpgrade = 0;
        this.goldSell = 500;
    }

    public override float GetDamage()
    {
        return damage;
    }

    public override void SetDamage()
    {
        damage += damageIncrease;
    }
}
