using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : GapiMonoBehaviour
{
    public static TowerManager instance;
    public GameObject obj;

    protected override void Awake()
    {
        base.Awake();
        TowerManager.instance = this;
    }

    public void SetObj()
    {
        obj = null;
    }
}
