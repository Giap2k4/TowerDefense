using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashUpgrade : UpgradeTower
{    
    protected override void Reset()
    {
        base.Reset();

        damage = 12;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 2.5f;

        this.goldUpLevel = 40;
        this.goldUpgrade = 1200;
        this.goldSell = 70;

        this.goldAfterUpgrade = 10;
    }

    protected void OnEnable()
    {
        damage = 12;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 2.5f;

        this.goldUpLevel = 40;
        this.goldUpgrade = 1200;
        this.goldSell = 70;
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
