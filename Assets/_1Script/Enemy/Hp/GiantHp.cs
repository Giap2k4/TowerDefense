using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHp : HpEnemy
{

    protected override void Reset()
    {
        this.nameSO = "Giant";

        base.Reset();

        this.hpBar = transform.Find("Hp").Find("Hp1");
    }

    private void OnEnable()
    {
        this.hp = 400 + (EnemyManager.instance.level * 150);
        this.hpFirst = 400 + (EnemyManager.instance.level * 150);

        this.hpScale = new Vector3(1, 1, 1);
        this.hpBar.localScale = this.hpScale;
    }
}
