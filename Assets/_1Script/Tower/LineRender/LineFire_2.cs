using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFire_2 : LineController
{
    protected override void LineAttack()
    {
        if (this.attack.listEnemy.Count == 0 || this.attack.listEnemy2.Count == 0)
        {
            this.lineRenderer.sortingOrder = 0;
            this.lineRenderer.positionCount = 2;
            this.lineRenderer.SetPosition(0, transform.position);
            this.lineRenderer.SetPosition(1, transform.position);

            return;
        }

        this.lineRenderer.positionCount = this.positionCount;

        Vector3 pos2 = transform.position;
        pos2.z = 0;

        this.lineRenderer.SetPosition(0, pos2);
        this.lineRenderer.sortingOrder = 6;

        for (int i = 0; i < this.attack.listEnemy2.Count; i++)
        {
            Vector3 pos1 = this.attack.listEnemy2[i].transform.position;
            
            pos1.z = 0;
            pos2.z = 0;

            this.lineRenderer.SetPosition(i * 2 + 1, pos1);
            this.lineRenderer.SetPosition(i * 2 + 2, pos2);
        }

        //if (this.attack.checkPause == true) return;

        this.fpsCount += Time.deltaTime;
        if (this.fpsCount >= 2f / this.fps)
        {
            this.animationStep++;
            if (this.animationStep == this.textures.Length) this.animationStep = 0;

            this.lineRenderer.material.SetTexture("_MainTex", this.textures[animationStep]);

            this.fpsCount = 0f;
        }
    }

}
