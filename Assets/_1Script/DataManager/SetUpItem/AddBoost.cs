using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoost : BaseButton
{
    protected override void OnClick()
    {
        DataSetUpItem.instance.AddBoost(1);
    }
}
