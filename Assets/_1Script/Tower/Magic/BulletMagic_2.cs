using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BulletMagic_2 : GapiMonoBehaviour
{
    [SerializeField] protected Magic_2 magic_2;
    [SerializeField] protected SpawnBulletMagic spawnBulletMagic;
    [SerializeField] protected Vector3 pos;

    [SerializeField] protected float timeLine = 0.05f;
    [SerializeField] protected float timeCount = 0f;

    [SerializeField] protected float speed = 30f;
    [SerializeField] protected float radius = 2f;

    [SerializeField] protected Vector3 scaleBullet;

    [SerializeField] protected bool hasSpawnedEffect = true;


    protected override void Reset()
    {
        base.Reset();

        this.magic_2 = transform.parent.parent.transform.GetComponent<Magic_2>();
        this.spawnBulletMagic = transform.parent.parent.transform.GetComponent<SpawnBulletMagic>();

        this.scaleBullet = new Vector3(1, 1, 1);

    }

    protected override void Start()
    {
        if (this.magic_2.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.magic_2.listEnemy2[0].transform.position;
    }

    protected void OnEnable()
    {
        if (this.magic_2.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.magic_2.listEnemy2[0].transform.position;
        this.scaleBullet = new Vector3(1, 1, 1);
        transform.localScale = this.scaleBullet;
        hasSpawnedEffect = true;
    }

    private void Update()
    {
        this.Movenment();
    }

    protected void Movenment()
    {
        transform.position = Vector3.MoveTowards(transform.position, this.pos, this.speed * Time.deltaTime);

        if (this.scaleBullet.x > 0.5)
        {
            this.scaleBullet.x -= 0.01f;
            this.scaleBullet.y -= 0.01f;
        }

        transform.localScale = this.scaleBullet;

        if (Vector3.Distance(transform.position, this.pos) < 0.05f)
        {
            if (this.hasSpawnedEffect)
            {
                EffectManager.instance.Spawn("MagicDead", transform.position, transform.rotation);
                hasSpawnedEffect = false;
            }


            this.timeCount += Time.deltaTime;
            if (this.timeCount < this.timeLine) return;

            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, this.radius, LayerMask.GetMask("Enemy"));

            bool isFirst = true;
            //foreach (var a in collider)
            //{
            //    HpEnemy hp = a.GetComponent<HpEnemy>();
            //    if (hp == null) return;

            //    if (isFirst)
            //    {
            //        hp.Damager(this.magic_2.damage);
            //        isFirst = false;
            //    }
            //    else hp.Damager(this.magic_2.damage / 2);
            //}

            foreach (var collider in hit)
            {
                GameObject obj = collider.gameObject;
                HpEnemy hp = collider.gameObject.GetComponent<HpEnemy>();
                if (hp == null) return;

                if (isFirst)
                {
                    if (obj.gameObject.name == "Small")
                    {
                        hp.Damager(this.magic_2.damage - (this.magic_2.damage * 0.2f));
                        isFirst = false;
                    }

                    if (obj.gameObject.name == "Giant")
                    {
                        hp.Damager(this.magic_2.damage);
                        isFirst = false;
                    }

                    if (obj.gameObject.name == "Wizard")
                    {
                        hp.Damager(this.magic_2.damage + (this.magic_2.damage * 1f));
                        isFirst = false;
                    }

                    if (obj.gameObject.name == "Witch")
                    {
                        hp.Damager(this.magic_2.damage - (this.magic_2.damage * 0.75f));
                        isFirst = false;
                    }
                }
                else
                {
                    if (obj.gameObject.name == "Small")
                    {
                        hp.Damager((this.magic_2.damage - (this.magic_2.damage * 0.1f)) / 2);
                        isFirst = false;
                    }

                    if (obj.gameObject.name == "Giant")
                    {
                        hp.Damager(this.magic_2.damage / 2);
                        isFirst = false;
                    }

                    if (obj.gameObject.name == "Wizard")
                    {
                        hp.Damager((this.magic_2.damage + (this.magic_2.damage * 1f)) / 2);
                        isFirst = false;
                    }

                    if (obj.gameObject.name == "Witch")
                    {
                        hp.Damager((this.magic_2.damage - (this.magic_2.damage * 0.75f)) / 2);
                        isFirst = false;
                    }

                }

            }


            this.spawnBulletMagic.AddObjPool(transform);
            
            this.timeCount = 0;

            return;
        }

    }
}
