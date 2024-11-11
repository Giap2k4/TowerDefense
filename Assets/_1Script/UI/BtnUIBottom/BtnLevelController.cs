using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLevelController : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 0;
    }
}
