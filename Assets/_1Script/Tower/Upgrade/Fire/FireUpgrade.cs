using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUpgrade : UpgradeTower
{
    
    protected override void Reset()
    {
        base.Reset();

        damage = 12;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 2.5f;

        this.goldUpLevel = 50;
        this.goldUpgrade = 4200;
        this.goldSell = 130;

        this.goldAfterUpgrade = 20;
    }

    protected void OnEnable()
    {
        damage = 12;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 2.5f;

        this.goldUpLevel = 50;
        this.goldUpgrade = 4200;
        this.goldSell = 130;
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
