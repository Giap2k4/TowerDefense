using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMvm : EnemyMovenment
{
    protected override void Reset()
    {
        this.nameSO = "Witch";
        base.Reset();
    }
}
