using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUpgrade : UpgradeTower
{
    protected override void Reset()
    {
        base.Reset();

        damage = 20;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 5.5f;

        this.goldUpLevel = 80;
        this.goldUpgrade = 9200;
        this.goldSell = 200;

        this.goldAfterUpgrade = 40;
    }

    protected void OnEnable()
    {
        damage = 20;
        this.range = 0.05f;
        this.timeAttack = 0.05f;
        this.damageIncrease = 5.5f;

        this.goldUpLevel = 80;
        this.goldUpgrade = 9200;
        this.goldSell = 200;
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
