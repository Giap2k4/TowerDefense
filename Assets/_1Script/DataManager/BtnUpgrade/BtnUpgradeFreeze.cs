using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgradeFreeze : BaseButton
{
    protected override void OnClick()
    {
        DataUpgrade.instance.UpgradeFreeze();
    }
}
