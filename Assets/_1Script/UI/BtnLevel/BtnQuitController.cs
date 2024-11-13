using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnQuitController : BaseButton
{
    protected override void OnClick()
    {
        HealthLevel.instance.CheckReward();
    }
}
