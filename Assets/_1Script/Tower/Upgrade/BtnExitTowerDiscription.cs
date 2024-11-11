using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitTowerDiscription : BaseButton
{
    protected override void OnClick()
    {
        TowerManager.instance.obj.transform.Find("Range/Range").gameObject.SetActive(false);
    }
}
