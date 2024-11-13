using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_2Upgrade : UpgradeTower
{
    protected override void Reset()
    {
        base.Reset();

        damage = 15;
        this.range = 0.02f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 3;

        this.goldUpLevel = 200;
        this.goldUpgrade = 0;
        this.goldSell = 800;

        this.goldAfterUpgrade = 30;
    }

    protected void OnEnable()
    {
        damage = 15;
        this.range = 0.02f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 3;

        this.goldUpLevel = 200;
        this.goldUpgrade = 0;
        this.goldSell = 800;
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
