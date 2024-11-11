using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceUpgrade : UpgradeTower
{    
    protected override void Reset()
    {
        base.Reset();

        damage = 0;
        this.range = 0;
        this.timeAttack = 0.05f;
        this.damageIncrease = 0;

        this.goldUpLevel = 200;
        this.goldUpgrade = 7200;
        this.goldSell = 400;

        this.goldAfterUpgrade = 35;

    }

    protected void OnEnable()
    {
        this.goldUpLevel = 200;
        this.goldUpgrade = 7200;
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
