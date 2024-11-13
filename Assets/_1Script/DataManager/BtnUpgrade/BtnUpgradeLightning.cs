using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgradeLightning : BaseButton
{
    protected override void OnClick()
    {
        DataUpgrade.instance.UpgradeLightning();
    }
}
