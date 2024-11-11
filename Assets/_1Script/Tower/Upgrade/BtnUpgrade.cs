using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgrade : BaseButton
{
    protected override void OnClick()
    {
        TowerManager.instance.obj.GetComponent<UpgradeTower>().Upgrade();
    }
}
