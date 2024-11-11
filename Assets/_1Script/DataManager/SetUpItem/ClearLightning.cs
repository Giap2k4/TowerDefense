using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLightning : BaseButton
{
    protected override void OnClick()
    {
        DataSetUpItem.instance.ClearLightning(1);
    }
}
