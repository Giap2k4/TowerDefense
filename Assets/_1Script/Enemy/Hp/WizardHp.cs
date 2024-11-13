using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardHp : HpEnemy
{
    protected override void Reset()
    {
        this.nameSO = "Wizard";

        base.Reset();

        this.hpBar = transform.Find("Hp").Find("Hp1");
    }

    private void OnEnable()
    {
        this.hp = 650 + (EnemyManager.instance.level * 260);
        this.hpFirst = 650 + (EnemyManager.instance.level * 260);

        this.hpScale = new Vector3(1, 1, 1);
        this.hpBar.localScale = this.hpScale;
    }
}
