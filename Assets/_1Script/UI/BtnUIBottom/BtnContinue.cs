using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnContinue : BaseButton
{
    [SerializeField] protected BtnPause btnPause;
    [SerializeField] protected AudioBtn audioBtn;

    protected override void Reset()
    {
        base.Reset();
        this.btnPause = GameObject.Find("BtnPause").transform.Find("Btn").GetComponent<BtnPause>();

        this.audioBtn = GameObject.Find("SoundManager/SoundBtn").GetComponent<AudioBtn>();
    }

    protected override void OnClick()
    {
        this.audioBtn.AudioPlay();

        this.btnPause.checkPause = false;

        this.ContinueEnemy();
        this.TowerContinue();
        
        this.btnPause.listEnemy.Clear();
        this.btnPause.enemyVelocity.Clear();
        this.btnPause.listTower.Clear();

        transform.parent.gameObject.SetActive(false);
    }

    protected void ContinueEnemy()
    {
        for (int i = 0; i < this.btnPause.listEnemy.Count; i++)
        {
            EnemyMovenment enemyMvm = this.btnPause.listEnemy[i].GetComponent<EnemyMovenment>();

            enemyMvm.speed = this.btnPause.enemyVelocity[i];
            enemyMvm.checkFreeze = false;
            enemyMvm.checkPause = false;
            enemyMvm.animator.speed = 1;
        }

        EnemyManager.instance.checkPause = false;
    }

    protected void TowerContinue()
    {
        for (int i = 0; i < this.btnPause.listTower.Count; i++)
        {
            Attack att = this.btnPause.listTower[i].transform.Find("Attack").GetComponent<Attack>();
            att.checkPause = false;
        }
    }
}
