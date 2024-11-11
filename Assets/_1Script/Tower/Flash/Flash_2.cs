using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_2 : Attack
{
    protected override void Reset()
    {
        this.range = 3f;
        base.Reset();

        this.quantityEnemy = 1;
        this.timeAttack = 1.25f;
        this.damage = 400;

        this.maxLevel = 15;
        
        this.circleCollider.radius = this.range;

        
    }

    protected void OnEnable()
    {
        //
        this.timeAttack = 1.25f;
        this.timeCheckAttack = 0;
        this.damage = 400;

        this.range = 3f;
        this.circleCollider.radius = this.range;
        this.checkRange.transform.localScale = this.scaleRangeObj;
        this.level = 1;

        if (this.btnPause.checkPause) this.checkPause = true;
        else this.checkPause = false;

        this.checkRange.SetActive(false);

        this.pos = transform.position;
        //this.pos.y += 0.4f;
        this.rot = transform.rotation;
    }

    
}
