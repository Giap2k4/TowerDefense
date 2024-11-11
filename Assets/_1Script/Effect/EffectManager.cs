using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Spawns
{
    public static EffectManager instance;
    //[SerializeField] protected Transform prefab;

    protected override void Awake()
    {
        base.Awake();
        EffectManager.instance = this;
    }

    //protected override void Reset()
    //{
    //    base.Reset();
    //    this.prefab = transform.Find("Prefab");

    //    foreach (Transform child in this.prefab)
    //    {
    //        this.prefabs.Add(child);
    //    }

    //}
}
