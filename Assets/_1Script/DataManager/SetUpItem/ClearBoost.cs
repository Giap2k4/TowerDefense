using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBoost : BaseButton
{
    protected override void OnClick()
    {
        DataSetUpItem.instance.ClearBoost(1);
    }
}
