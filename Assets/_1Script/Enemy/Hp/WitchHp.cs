using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHp : HpEnemy
{
    [SerializeField] protected float timeCount = 0;
    [SerializeField] protected float timeLine = 3f;
    [SerializeField] protected float heal = 0.1f;

    [SerializeField] protected EnemyMovenment enemyMvm;

    protected override void Reset()
    {
        this.nameSO = "Witch";

        base.Reset();

        this.hpBar = transform.Find("Hp").Find("Hp1");
        this.enemyMvm = GetComponent<EnemyMovenment>();
    }

    private void OnEnable()
    {

        this.hp = 550 + (EnemyManager.instance.level * 150);
        this.hpFirst = 550 + (EnemyManager.instance.level * 150);

        this.hpScale = new Vector3(1, 1, 1);
        this.hpBar.localScale = this.hpScale;
    }

    protected void Update()
    {
        if (this.enemyMvm.checkPause) return;

        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;
        this.timeCount = 0;

        this.hp += (this.hpFirst * this.heal);
        this.hpScale.x += this.heal;
        this.hpBar.localScale = this.hpScale;

        if (this.hp >= this.hpFirst)
        {
            this.hpScale = new Vector3(1, 1, 1);
            this.hpBar.localScale = this.hpScale;
            this.hp = this.hpFirst;
        }

    }
}
