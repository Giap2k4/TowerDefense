using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEff : GapiMonoBehaviour
{
    [SerializeField] protected float timeLine = 1f;
    [SerializeField] protected float timeCount = 0;

    void Update()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;
        this.timeCount = 0;

        EffectManager.instance.AddObjPool(transform);
    }
}
