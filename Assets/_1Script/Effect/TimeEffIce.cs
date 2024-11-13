using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEffIce : GapiMonoBehaviour
{

    [SerializeField] protected float timeLine = 0.7f;
    [SerializeField] protected float timeCount = 0;

    protected void OnEnable()
    {
        this.timeCount = 0;
    }

    void Update()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;
        
        gameObject.SetActive(false);
        
    }
}
