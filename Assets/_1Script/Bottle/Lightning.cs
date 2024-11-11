using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : GapiMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] public List<Transform> listEnemy;

    [SerializeField] protected float damagerCount = 500;

    [SerializeField] public bool checkListEmpty = false;


    protected override void Reset()
    {
        base.Reset();
        this.holder = GameObject.Find("Enemy").transform.Find("Holder");

    }

    protected void OnEnable()
    {
        this.damagerCount = MainScore.instance.LoadFloat("parameterLightning", 500);

        this.LightningEnemy();
    }

    public void AddEnemy()
    {
        foreach (Transform child in this.holder)
        {
            if (child.gameObject.activeSelf == true)
            {
                this.listEnemy.Add(child);
            }
        }

        if (this.listEnemy.Count == 0)
        {
            this.checkListEmpty = true;
        }
        else this.checkListEmpty = false;
    }

    public void LightningEnemy()
    {
        if (this.listEnemy.Count == 0) return;

        for (int i = 0; i < this.listEnemy.Count; i++)
        {

            if (this.listEnemy[i] == null)
            {
                this.listEnemy.RemoveAt(i);
                i--;
                continue;
            }

            GameObject obj = this.listEnemy[i].transform.Find("EffLightning").gameObject;
            HpEnemy hpEnemy = this.listEnemy[i].GetComponent<HpEnemy>();
            Vector3 pos = this.listEnemy[i].position;
            pos.y += 2f;

            obj.SetActive(true);

            if (this.damagerCount > hpEnemy.hp)
            {
                obj.transform.parent = obj.transform.parent.parent.parent;
                obj.transform.position = pos;
            }

            hpEnemy.Damager(this.damagerCount);

        }

        this.listEnemy.Clear ();

        gameObject.SetActive(false);
    } 
}
