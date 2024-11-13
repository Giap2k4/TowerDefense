using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragMagic : DragAndDrop
{
    protected override void Reset()
    {
        base.Reset();
        this.nameTower = "Magic";

        this.objImage = GameObject.Find("Object").transform.Find("Tower").transform.Find("Asset").transform.Find("Magic");
        this.checkGold = 300;
    }
}
