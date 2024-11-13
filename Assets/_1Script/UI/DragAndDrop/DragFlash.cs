using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragFlash : DragAndDrop
{
    protected override void Reset()
    {
        base.Reset();
        this.nameTower = "Flash";

        this.objImage = GameObject.Find("Object").transform.Find("Tower").transform.Find("Asset").transform.Find("Flash");

        this.checkGold = 100;
    }
}
