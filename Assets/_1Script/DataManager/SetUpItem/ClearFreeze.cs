using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFreeze : BaseButton
{
    protected override void OnClick()
    {
        DataSetUpItem.instance.ClearFreeze(1);
    }
}
