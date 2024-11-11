using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_1 : Attack
{
    protected override void Reset()
    {
        this.range = 2.7f;
        base.Reset();

        this.quantityEnemy = 1;
        this.timeAttack = 1.5f;
        this.damage = 180;

        this.maxLevel = 10;
        this.circleCollider.radius = this.range;

    }

    protected void OnEnable()
    {
        //
        this.timeAttack = 1.5f;
        this.timeCheckAttack = 0;
        this.damage = 180;

        this.range = 2.7f;
        this.circleCollider.radius = this.range;
        this.checkRange.transform.localScale = this.scaleRangeObj;

        this.level = 1;

        if (this.btnPause.checkPause) this.checkPause = true;
        else this.checkPause = false;
        this.checkRange.SetActive(false);

        this.pos = transform.position;
        this.pos.y += 0.2f;
        this.rot = transform.rotation;
    }
}
