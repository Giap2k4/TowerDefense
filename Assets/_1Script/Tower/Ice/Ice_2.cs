using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_2 : Attack
{
    //[SerializeField] protected EnemyMovenment enemyMovenment;
    protected override void Reset()
    {

        this.range = 2.5f;
        base.Reset();

        this.quantityEnemy = 1;
        this.timeAttack = 2.5f;
        this.damage = 0;

        this.maxLevel = 3;
        
        this.circleCollider.radius = this.range;

        this.checkAddEnemy = true;

        
    }

    protected void OnEnable()
    {
        this.timeAttack = 2.5f;
        this.timeCheckAttack = 0;
        this.level = 1;

        this.range = 2.5f;
        this.circleCollider.radius = this.range;
        this.checkRange.transform.localScale = this.scaleRangeObj;

        if (this.btnPause.checkPause) this.checkPause = true;
        else this.checkPause = false;
        this.checkRange.SetActive(false);
    }

    protected override void CanAttack()
    {
        this.audioTowerAttack.AudioPlay();
        this.spawnBulletMagic.Spawn("bullet", pos, rot);

        this.timeCheckAttack = 0;

    }
}
