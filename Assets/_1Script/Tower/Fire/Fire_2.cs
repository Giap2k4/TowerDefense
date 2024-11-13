using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_2 : Attack
{
    protected override void Reset()
    {
        this.range = 2.5f;
        base.Reset();

        this.quantityEnemy = 3;
        this.timeAttack = 0.1f;
        this.damage = 10;

        this.maxLevel = 10;
        
        this.circleCollider.radius = this.range;

    }

    protected void OnEnable()
    {
        //

        this.timeAttack = 0.1f;
        this.damage = 10;

        this.maxLevel = 10;
        this.range = 2.5f;
        this.circleCollider.radius = this.range;
        this.checkRange.transform.localScale = this.scaleRangeObj;

        if (this.btnPause.checkPause) this.checkPause = true;
        else this.checkPause = false;
        this.checkRange.SetActive(false);
    }

    protected override void CanAttack()
    {
        if (this.listEnemy2.Count == 0) return;

        this.audioTowerAttack.AudioPlay();

        this.lineController.positionCount = this.listEnemy2.Count * 2 + 1;

        for (int i = 0; i < this.listEnemy2.Count; i++)
        {
            GameObject obj = this.listEnemy2[i].transform.gameObject;
            if (obj.name == "Small" || obj.name == "Witch")
            {
                this.listEnemy2[i].Damager(this.damage);
            }
            else if (obj.name == "Giant")
            {
                this.listEnemy2[i].Damager(this.damage + (this.damage * 0.25f));
            }
            else if (obj.name == "Wizard")
            {
                this.listEnemy2[i].Damager(this.damage - (this.damage * 0.6f));
            }
        }

        this.timeCheckAttack = 0;
    }
}
