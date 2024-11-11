using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_2Upgrade : UpgradeTower
{
    protected override void Reset()
    {
        base.Reset();

        damage = 5;
        this.range = 0.05f;
        this.timeAttack = 0;
        this.damageIncrease = 2f;

        this.goldUpLevel = 300;
        this.goldUpgrade = 0;
        this.goldSell = 700;

        this.goldAfterUpgrade = 35;
    }

    protected void OnEnable()
    {
        damage = 2;
        this.range = 0.05f;
        this.timeAttack = 0;
        this.damageIncrease = 1;

        this.goldUpLevel = 300;
        this.goldUpgrade = 0;
        this.goldSell = 700;
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
