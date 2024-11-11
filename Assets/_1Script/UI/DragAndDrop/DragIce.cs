using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragIce : DragAndDrop
{
    protected override void Reset()
    {
        base.Reset();
        this.nameTower = "Ice";

        this.objImage = GameObject.Find("Object").transform.Find("Tower").transform.Find("Asset").transform.Find("Ice");
        this.checkGold = 500;
    }
}
