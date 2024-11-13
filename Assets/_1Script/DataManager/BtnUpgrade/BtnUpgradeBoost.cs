using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgradeBoost : BaseButton
{
    protected override void OnClick()
    {
        DataUpgrade.instance.UpgradeBoost();
    }
}
