using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIce_2 : GapiMonoBehaviour
{
    [SerializeField] protected Ice_2 ice_2;
    [SerializeField] protected SpawnBulletMagic spawnBulletMagic;
    [SerializeField] protected Vector3 pos;
    [SerializeField] protected Vector3 scaleBullet;

    [SerializeField] protected float speed = 45f;

    protected override void Reset()
    {
        base.Reset();

        this.ice_2 = transform.parent.parent.transform.GetComponent<Ice_2>();
        this.spawnBulletMagic = transform.parent.parent.transform.GetComponent<SpawnBulletMagic>();
        this.scaleBullet = new Vector3(1, 1, 1);
    }

    protected override void Start()
    {
        if (this.ice_2.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.ice_2.listEnemy2[0].transform.position;

    }

    protected void OnEnable()
    {
        if (this.ice_2.listEnemy2.Count == 0)
        {
            this.spawnBulletMagic.AddObjPool(transform);
            return;
        }

        this.pos = this.ice_2.listEnemy2[0].transform.position;

        this.scaleBullet = new Vector3(1, 1, 1);
        transform.localScale = this.scaleBullet;
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

        if (Vector3.Distance(transform.position, this.pos) < 0.01f)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Enemy"));

            if (hit != null)
            {
                EnemyMovenment enemyMovenment = hit.gameObject.GetComponent<EnemyMovenment>();
                enemyMovenment.transform.position = enemyMovenment.posSpawn[0];
                enemyMovenment.counter = 0;
                enemyMovenment.checkIce_2 = false;
                enemyMovenment.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 0.6f, 1f, 1f);

                this.ice_2.listEnemy2.Remove(hit.gameObject.GetComponent<HpEnemy>());
                this.ice_2.listEnemy.Remove(hit.gameObject.GetComponent<HpEnemy>());
            }

            this.spawnBulletMagic.AddObjPool(transform);
        }
    }
}
