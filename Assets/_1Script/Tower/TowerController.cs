using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : Spawns
{
    public static TowerController instance;

    protected override void Awake()
    {
        base.Awake();
        TowerController.instance = this;
    }

}
