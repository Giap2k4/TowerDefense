using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMvm : EnemyMovenment
{
    protected override void Reset()
    {
        this.nameSO = "Wizard";
        base.Reset();
    }
}
