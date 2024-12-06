using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameMap : GapiMonoBehaviour
{
    [SerializeField] protected Text txtNameMap;

    protected override void Reset()
    {
        base.Reset();
        this.txtNameMap = transform.Find("_Txt").GetComponent<Text>();
    }

    protected override void Start()
    {
        base.Start();

        this.txtNameMap.text = "Bản đồ " + ScrollLevel.nameMap;
    }
}
