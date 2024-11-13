using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_1 : Attack
{
    [SerializeField] protected float speed = 0.3f;
    [SerializeField] protected float movenmentMin = 0.5f;

    [SerializeField] protected bool hasSpawnedEffect = true;

    [SerializeField] protected Transform particleEff;

    protected override void Reset()
    {

        this.range = 1.5f;
        base.Reset();

        this.quantityEnemy = 20;
        this.timeAttack = 2f;
        this.damage = 0;

        this.maxLevel = 5;
        
        this.circleCollider.radius = this.range;

        this.particleEff = transform.parent.Find("ParticleEff");

        
    }

    protected void OnEnable()
    {
        this.hasSpawnedEffect = true;
        this.timeAttack = 2f;
        this.timeCheckAttack = 0;
        this.level = 1;
        this.checkRange.transform.localScale = this.scaleRangeObj;

        if (this.btnPause.checkPause) this.checkPause = true;
        else this.checkPause = false;
        this.checkRange.SetActive(false);
    }

    protected override void CanAttack()
    {
        this.audioTowerAttack.AudioPlay();
        this.particleEff.gameObject.SetActive(true);

        for (int i = 0; i < this.listEnemy2.Count; i++)
        {
            EnemyMovenment enemyMvm = this.listEnemy2[i].transform.GetComponent<EnemyMovenment>();

            if (enemyMvm.speed <= this.movenmentMin) break;

            enemyMvm.speed -= this.speed;

            if (enemyMvm.speed <= this.movenmentMin) enemyMvm.speed = this.movenmentMin;
        }

        this.timeCheckAttack = 0;
        this.hasSpawnedEffect = true;
    }
}
