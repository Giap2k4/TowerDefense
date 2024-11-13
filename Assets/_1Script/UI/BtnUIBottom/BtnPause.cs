using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : BaseButton
{
    [SerializeField] protected Transform holderEnemy;
    [SerializeField] protected Transform holderTower;

    [SerializeField] public List<Transform> listEnemy;
    [SerializeField] public List<Transform> listTower;

    [SerializeField] public List<float> enemyVelocity;

    [SerializeField] public bool checkPause = false;

    [SerializeField] protected AudioBtn audioBtn;


    protected override void Reset()
    {
        base.Reset();
        this.holderEnemy = GameObject.Find("Enemy").transform.Find("Holder");
        this.holderTower = GameObject.Find("Tower").transform.Find("Holder");

        this.audioBtn = GameObject.Find("SoundManager/SoundBtn").GetComponent<AudioBtn>();

    }
    protected override void OnClick()
    {
        this.audioBtn.AudioPlay();

        this.checkPause = true;

        this.listEnemy.Clear();
        this.enemyVelocity.Clear();

        EnemyManager.instance.checkPause = true;

        this.AddEnemy();
        this.AddTower();

        this.PauseTower();
        this.PauseEnemy();

        transform.parent.gameObject.SetActive(false);
    }

    protected void AddEnemy()
    {
        foreach (Transform child in this.holderEnemy)
        {
            if (child.gameObject.activeSelf == true)
            {
                this.listEnemy.Add(child);
            }
        }
    }

    protected void PauseEnemy()
    {
        if (this.listEnemy.Count == 0) return;

        for (int i = 0; i < this.listEnemy.Count; i++)
        {
            EnemyMovenment enemyMvm = this.listEnemy[i].GetComponent<EnemyMovenment>();

            //if (enemyMvm == null)
            //{
            //    i--;
            //    continue;
            //}
            this.enemyVelocity.Add(enemyMvm.speed);

            enemyMvm.speed = 0;
            enemyMvm.checkPause = true;
            enemyMvm.animator.speed = 0;
        }
    }

    protected void AddTower()
    {
        foreach (Transform child in this.holderTower)
        {
            if (child.gameObject.activeSelf == true)
            {
                this.listTower.Add(child);
            }
        }
    }

    protected void PauseTower()
    {
        if (this.listTower.Count == 0) return;

        for (int i = 0; i < this.listTower.Count; i++)
        {
            Attack att = this.listTower[i].transform.Find("Attack").GetComponent<Attack>();

            att.checkPause = true;
        }
    }

}
