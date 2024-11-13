using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_2 : Attack
{

    [SerializeField] protected float timeLine = 0.3f;
    [SerializeField] protected float timeCount = 0f;

    [SerializeField] protected int quantityBullet = 3;

    protected override void Reset()
    {
        this.range = 3f;

        base.Reset();

        this.quantityEnemy = 1;
        this.timeAttack = 2f;
        this.damage = 400;
        this.checkAddEnemy = false;

        this.maxLevel = 15;
        
        this.circleCollider.radius = this.range;

        this.spawnBulletMagic = GetComponent<SpawnBulletMagic>();

        

    }
    protected override void Start()
    {
        base.Start();

        this.pos = transform.position;
        this.pos.y += 0.2f;
        this.rot = transform.rotation;
    }

    protected void OnEnable()
    {
        //
        this.timeAttack = 2;
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
        this.pos.y += 0.2f;
        this.rot = transform.rotation;
    }

    protected override void AttackEnemy()
    {
        if (!this.btnPause.checkPause) this.checkPause = false;

        if (this.listEnemy.Count == 0 || this.checkPause)
        {
            this.timeCount = 0;
            this.quantityBullet = 3;

            this.timeCheckAttack = 0;
            return;
        }

        this.timeCheckAttack += Time.deltaTime;
        if (this.timeCheckAttack < this.timeAttack) return;

        this.CheckEnemyHpAttack();

        this.CanAttack();

    }

    protected override void CanAttack()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;

        this.spawnBulletMagic.Spawn("bullet", pos, rot);
        this.quantityBullet--;
        this.timeCount = 0;

        this.audioTowerAttack.AudioPlay();


        if (this.quantityBullet > 0) return;

        this.listEnemy2.Clear();
        this.quantityBullet = 3;
        this.timeCheckAttack = 0;
    }
}
