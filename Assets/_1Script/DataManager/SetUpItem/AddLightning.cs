using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLightning : BaseButton
{
    protected override void OnClick()
    {
        DataSetUpItem.instance.AddLightning(1);
    }
}
