using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlash_1 : GapiMonoBehaviour
{
    [SerializeField] protected Flash_1 flash_1;
    [SerializeField] protected SpawnBulletMagic spawnBulletMagic;
    [SerializeField] protected Vector3 pos;

    [SerializeField] protected LineController lineController;

    [SerializeField] protected float speed = 65f;

    protected override void Reset()
    {
        base.Reset();

        this.flash_1 = transform.parent.parent.transform.GetComponent<Flash_1>();
        this.spawnBulletMagic = transform.parent.parent.transform.GetComponent<SpawnBulletMagic>();

        lineController = transform.parent.parent.GetComponent<LineController>();
    }

    protected override void Start()
    {
        if (this.flash_1.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.flash_1.listEnemy2[0].transform.position;

    }

    protected void OnEnable()
    {
        if (this.flash_1.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.flash_1.listEnemy2[0].transform.position;
    }

    private void Update()
    {
        this.Movenment();
    }

    protected void Movenment()
    {
        transform.position = Vector3.MoveTowards(transform.position, this.pos, this.speed * Time.deltaTime);
        
        this.lineController.pos = transform.position;

        if (transform.position == this.pos)
        {
            
            Collider2D hitEnemy = Physics2D.OverlapCircle(transform.position, 0.06f, LayerMask.GetMask("Enemy"));

            if (hitEnemy != null)
            {
                HpEnemy hp = hitEnemy.gameObject.GetComponent<HpEnemy>();
                if (hp == null) return;

                if (hitEnemy.gameObject.name == "Small")
                {
                    hp.Damager(this.flash_1.damage + (this.flash_1.damage * 0.5f));
                }

                if (hitEnemy.gameObject.name == "Giant")
                {
                    hp.Damager(this.flash_1.damage - (this.flash_1.damage * 0.7f));
                }

                if (hitEnemy.gameObject.name == "Wizard")
                {
                    hp.Damager(this.flash_1.damage);
                }

                if (hitEnemy.gameObject.name == "Witch")
                {
                    hp.Damager(this.flash_1.damage);
                }
            }
            else
            {
                this.spawnBulletMagic.AddObjPool(transform);
                this.lineController.pos = new Vector3(0, 0, 0);
                return;
            }

            this.spawnBulletMagic.AddObjPool(transform);
        }
        if (!gameObject.activeSelf)
        {
            this.lineController.pos = new Vector3(0, 0, 0);
        }
    }
}
