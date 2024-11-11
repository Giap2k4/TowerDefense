using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgradeBottle : BaseButton
{
    
    protected override void OnClick()
    {
        DataUpgrade.instance.UpgradeBottle();
    }
}
