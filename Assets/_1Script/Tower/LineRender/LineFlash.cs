using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFlash : LineController
{

    protected override void LineAttack()
    {
        this.positionCount = 2;
        base.LineAttack();
    }

}
