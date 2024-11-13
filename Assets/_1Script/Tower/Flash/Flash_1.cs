using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_1 : Attack
{
    [SerializeField] protected float lineRendererTimer = 0;
    [SerializeField] protected bool isLineRendererActive = false;
    protected override void Reset()
    {
        this.range = 2.5f;
        base.Reset();

        this.quantityEnemy = 1;
        this.timeAttack = 1f;
        this.damage = 100;

        this.maxLevel = 10;
        
        this.circleCollider.radius = this.range;

    }

    protected void OnEnable()
    {
        //
        this.timeAttack = 1f;
        this.timeCheckAttack = 0;
        this.damage = 100;

        this.range = 2.5f;
        this.circleCollider.radius = this.range;
        this.checkRange.transform.localScale = this.scaleRangeObj;
        this.level = 1;

        this.checkRange.SetActive(false);
        this.checkRange.transform.localScale = this.scaleRangeObj;

        if (this.btnPause.checkPause) this.checkPause = true;
        else this.checkPause = false;

        this.pos = transform.position;
        this.pos.y += 0.2f;
        this.rot = transform.rotation;
    }

}
