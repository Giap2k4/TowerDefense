using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffLightningParent : GapiMonoBehaviour
{
    [SerializeField] protected Transform parentEff;

    [SerializeField] protected float timeLine = 0.5f;
    [SerializeField] protected float timeCount = 0;

    protected override void Reset()
    {
        base.Reset();

        this.parentEff = transform.parent;
    }

    void Update()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;
        this.timeCount = 0;

        transform.parent = this.parentEff;
        gameObject.SetActive(false);
    }
}
