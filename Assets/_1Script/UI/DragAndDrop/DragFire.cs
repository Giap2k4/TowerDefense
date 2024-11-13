using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragFire : DragAndDrop
{
    protected override void Reset()
    {
        base.Reset();
        this.nameTower = "Fire";

        this.objImage = GameObject.Find("Object/Tower/Asset/Fire").transform;
        this.checkGold = 150;
    }
}
