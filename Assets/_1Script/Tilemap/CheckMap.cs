using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMap : GapiMonoBehaviour
{
    [SerializeField] protected GameObject tilemap;

    protected override void Awake()
    {
        base.Awake();
        this.tilemap = transform.Find("Map/Map_" + ScrollLevel.nameMap).gameObject;
        this.tilemap.SetActive(true);
    }
}
