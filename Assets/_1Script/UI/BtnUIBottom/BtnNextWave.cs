using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNextWave : BaseButton
{
    [SerializeField] protected RectTransform nextLevel;
    [SerializeField] protected AudioBtn audioBtn;

    protected override void Reset()
    {
        base.Reset();
        this.nextLevel = transform.parent.GetComponent<RectTransform>();

        this.audioBtn = GameObject.Find("SoundManager/SoundBtn").GetComponent<AudioBtn>();
    }
    protected override void OnClick()
    {
        this.audioBtn.AudioPlay();
        EnemyManager.instance.nextLevel = true;

        if (EnemyManager.instance.level != 1)
        {
            GoldLevel.instance.GoldCollect(EnemyManager.instance.level * EnemyManager.instance.goldNextLevel);
        }

        this.nextLevel.gameObject.SetActive(false);
    }
}
