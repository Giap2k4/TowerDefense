using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnContinueController : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
    }
}
