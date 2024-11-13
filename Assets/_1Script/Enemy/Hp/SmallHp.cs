using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHp : HpEnemy
{
    protected override void Reset()
    {
        this.nameSO = "Small";

        base.Reset();
        
        this.hpBar = transform.Find("Hp").Find("Hp1");
    }

    private void OnEnable()
    {
        if (EnemyManager.instance.level == 1)
        {
            this.hp = this.enemySO.hp;
            this.hpFirst = this.enemySO.hp;

            this.hpScale = new Vector3(1, 1, 1);
            this.hpBar.localScale = this.hpScale;

            return;
        }

        this.hp = 270 + (EnemyManager.instance.level * 100);
        this.hpFirst = 270 + (EnemyManager.instance.level * 100);

        this.hpScale = new Vector3(1, 1, 1);
        this.hpBar.localScale = this.hpScale;
    }
}
