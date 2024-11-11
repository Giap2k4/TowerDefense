using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosBtnNextWave : GapiMonoBehaviour
{
    [SerializeField] protected Vector3 pos; 
    [SerializeField] protected PosSpawnEnemy posSpawnEnemySO;

    protected override void Start()
    {
        base.Start();

        this.posSpawnEnemySO = Resources.Load<PosSpawnEnemy>("PosSpawn");

        this.pos = this.posSpawnEnemySO.listPos[Convert.ToInt32(ScrollLevel.nameMap) - 1];
        
        if (this.pos.x > 5)
        {
            this.pos.x -= 1.5f;
        } else if (this.pos.x < -5)
        {
            this.pos.x += 1.5f;
        }

        transform.position = this.pos;
    }
}
