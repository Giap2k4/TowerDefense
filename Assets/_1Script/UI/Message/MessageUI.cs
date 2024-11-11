using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUI : GapiMonoBehaviour
{
    protected float timeLine = 1.5f;
    protected float timeCount = 0;

    protected void Update()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;
        this.timeCount = 0;

        gameObject.SetActive(false);
    }

}
