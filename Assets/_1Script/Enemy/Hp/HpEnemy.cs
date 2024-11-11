using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemy : GapiMonoBehaviour
{
    [SerializeField] protected EnemySO enemySO;
    [SerializeField] protected string nameSO;

    [SerializeField] public float hp = 0;
    [SerializeField] public float hpFirst = 0;

    [SerializeField] protected Transform hpBar;
    [SerializeField] protected Vector3 hpScale;

    [SerializeField] protected int goldDead;

    protected override void Reset()
    {
        base.Reset();
        this.enemySO = Resources.Load<EnemySO>(this.nameSO);

        this.hp = this.enemySO.hp;
        this.hpFirst = this.enemySO.hp;
        this.goldDead = this.enemySO.goldDead;
    }

    protected override void Start()
    {
        base.Start();
        this.hpScale = this.hpBar.transform.localScale;
    }

    public virtual void Damager (float damager)
    {
        this.hp -= damager;

        this.hpScale.x -= (float) damager / hpFirst;
        this.hpBar.transform.localScale = this.hpScale;

        if (this.IsDead()) this.Despawn();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    public virtual void Despawn()
    {
        GoldLevel.instance.GoldCollect(this.goldDead);

        HpEnemy hpEnemy = transform.GetComponent<HpEnemy>();
        EffectManager.instance.Spawn("EnemyDead", transform.position, transform.rotation);

        if (Attack.instance != null)
        {
            if (Attack.instance.listEnemy.Contains(hpEnemy) && Attack.instance.listEnemy2.Contains(hpEnemy))
            {
                Attack.instance.listEnemy.Remove(hpEnemy);
                Attack.instance.listEnemy2.Remove(hpEnemy);
            }
        }
        
        EnemyManager.instance.AddObjPool(transform);
    }
}
