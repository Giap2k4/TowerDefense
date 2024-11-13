using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMvm : EnemyMovenment
{
    protected override void Reset()
    {
        this.nameSO = "Small";
        base.Reset();
    }
}
