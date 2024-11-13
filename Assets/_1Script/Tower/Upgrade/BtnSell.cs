using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSell : BaseButton
{
    [SerializeField] protected AudioSellTower audioSellTower;

    protected override void Reset()
    {
        base.Reset();
        this.audioSellTower = GameObject.Find("SoundManager/SellTower").GetComponent<AudioSellTower>();
    }
    protected override void OnClick()
    {
        this.audioSellTower.audioSource.Play();
        TowerManager.instance.obj.GetComponent<UpgradeTower>().Sell();
    }
}
