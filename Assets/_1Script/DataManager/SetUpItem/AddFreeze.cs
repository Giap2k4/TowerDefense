using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFreeze : BaseButton
{
    protected override void OnClick()
    {
        DataSetUpItem.instance.AddFreeze(1);
    }
}
