using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantMvm : EnemyMovenment
{
    protected override void Reset()
    {
        this.nameSO = "Giant";
        base.Reset();
    }
}
