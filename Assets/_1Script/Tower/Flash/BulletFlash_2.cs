using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlash_2 : GapiMonoBehaviour
{
    [SerializeField] protected Flash_2 flash_2;
    [SerializeField] protected SpawnBulletMagic spawnBulletMagic;
    [SerializeField] protected Vector3 pos;

    [SerializeField] protected LineController lineController;

    [SerializeField] protected float speed = 65f;

    protected override void Reset()
    {
        base.Reset();

        this.flash_2 = transform.parent.parent.transform.GetComponent<Flash_2>();
        this.spawnBulletMagic = transform.parent.parent.transform.GetComponent<SpawnBulletMagic>();

        lineController = transform.parent.parent.GetComponent<LineController>();
    }

    protected override void Start()
    {
        if (this.flash_2.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.flash_2.listEnemy2[0].transform.position;

    }

    protected void OnEnable()
    {
        if (this.flash_2.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.flash_2.listEnemy2[0].transform.position;
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

                hp.Damager(this.flash_2.damage);
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
