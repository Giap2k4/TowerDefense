using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTargetTower : BaseButton
{
    [SerializeField] protected Attack attack;
    [SerializeField] protected Text txtTextTarget;

    [SerializeField] protected AudioBtn audioBtn;

    protected override void Reset()
    {
        base.Reset();

        this.txtTextTarget = transform.Find("_Txt").GetComponent<Text>();
        this.audioBtn = GameObject.Find("SoundManager/SoundBtn").GetComponent <AudioBtn>();
    }

    protected override void OnClick()
    {
        this.audioBtn.AudioPlay();

        this.attack = TowerManager.instance.obj.transform.Find("Attack").GetComponent<Attack>();
        if (this.attack == null) return;

        if (this.attack.checkTarget == 4)
        {
            this.attack.checkTarget = 1;
            this.txtTextTarget.text = "Máu ít nhất";
            return;
        }

        this.attack.checkTarget += 1;

        if (this.attack.checkTarget == 1)
        {
            this.txtTextTarget.text = "Máu ít nhất";
        }
        else if (this.attack.checkTarget == 2)
        {
            this.txtTextTarget.text = "Máu nhiều nhất";
        }
        else if (this.attack.checkTarget == 3)
        {
            this.txtTextTarget.text = "Gần nhất";
        }
        else if (this.attack.checkTarget == 4)
        {
            this.txtTextTarget.text = "Xa nhất";
        }
    }
}
