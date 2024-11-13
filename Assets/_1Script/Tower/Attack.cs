using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Attack : GapiMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public CircleCollider2D circleCollider;

    public static Attack instance;

    [SerializeField] protected int quantityEnemy = 1;
    public List<HpEnemy> listEnemy;
    public List<HpEnemy> listEnemy2;
    [SerializeField] protected SpawnBulletMagic spawnBulletMagic;
    [SerializeField] protected LineController lineController;

    [SerializeField] protected Vector3 pos;
    [SerializeField] protected Quaternion rot;

    public float timeAttack = 1f;
    public float timeCheckAttack = 0;

    public float damage = 30;
    public int level = 1;
    public int maxLevel = 1;

    public float range;
    public GameObject checkRange;
    [SerializeField] protected Vector3 scaleRangeObj;

    [SerializeField] protected bool checkAddEnemy = false;

    public bool hpMin = true;
    public bool hpMax = false;
    public bool distanceMin = false;
    public bool distanceMax = false;
    public int checkTarget;
    [SerializeField] protected List<bool> listTarget;

    [SerializeField] protected BtnPause btnPause;
    public bool checkPause = false;

    public TextMeshPro txtLevel;

    [SerializeField] protected AudioTowerAttack audioTowerAttack;

    protected override void Reset()
    {
        base.Reset();
        this.rb = GetComponent<Rigidbody2D>();
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.lineController = GetComponent<LineController>();
        this.spawnBulletMagic = GetComponent<SpawnBulletMagic>();

        this.btnPause = GameObject.Find("BtnPause/Btn").GetComponent<BtnPause>();
        this.checkRange = transform.parent.Find("Range/Range").gameObject;
        this.scaleRangeObj = new Vector3(this.range, this.range, 0);

        this.checkTarget = 1;

        this.txtLevel = transform.parent.Find("Model").GetComponent<TextMeshPro>();

        this.audioTowerAttack = transform.parent.GetComponent<AudioTowerAttack>();

        this.listTarget = new List<bool>() {this.hpMin, this.hpMax, this.distanceMin, this.distanceMax };
    }

    protected override void Awake()
    {
        base.Awake();
        Attack.instance = this;
    }

    protected override void Start()
    {
        base.Start();

        this.pos = transform.position;
        this.pos.y += 0.2f;
        this.rot = transform.rotation;

        this.checkRange.transform.localScale = this.scaleRangeObj;

        if (this.btnPause.checkPause) this.checkPause = true;
    }

    private void Update()
    {
        if (this.checkPause)
        {
            this.txtLevel.text = this.level.ToString();
        }

        this.txtLevel.text = "";

        this.CheckTarget();
        this.AttackEnemy();
        
    }


    protected void CheckTarget()
    {
        for (int i = 0; i < this.listTarget.Count; i++)
        {
            if (this.checkTarget == i + 1)
            {
                this.listTarget[i] = true;
                continue;
            }

            this.listTarget[i] = false;
        }
    }



    protected virtual void AttackEnemy()
    {
        if (!this.btnPause.checkPause) this.checkPause = false;

        if (this.listEnemy.Count == 0 || this.checkPause)
        {
            this.timeCheckAttack = 0;
            this.audioTowerAttack.AudioStop();
            return;
        }

        this.timeCheckAttack += Time.deltaTime;
        if (this.timeCheckAttack < this.timeAttack) return;

        this.CheckEnemyHpAttack();

        this.CanAttack();

    }

    protected void CheckEnemyHpAttack()
    {
        if (this.hpMin || this.hpMax)
        {
            this.CheckHP();        
        }

        if (this.distanceMin || this.distanceMax)
        {
            this.CheckDistance();
        }

    }

    protected void CheckHP()
    {
        for (int i = 0; i < this.listEnemy.Count - 1; i++)
        {
            for (int j = i + 1; j < this.listEnemy.Count; j++)
            {
                if (this.listEnemy[i].hp > this.listEnemy[j].hp)
                {
                    HpEnemy temp = this.listEnemy[i];
                    this.listEnemy[i] = this.listEnemy[j];
                    this.listEnemy[j] = temp;
                }
            }
        }

        if (this.hpMin)
        {
            this.ListFirst();
        }

        if (this.hpMax)
        {
            this.ListLast();
        }
    }

    protected void CheckDistance()
    {
        if (this.distanceMin)
        {
            this.ListFirst();
        }

        if (this.distanceMax)
        {
            this.ListLast();
        }
    }

    protected void ListFirst()
    {
        for (int i = 0; i < this.listEnemy.Count; i++)
        {
            if (this.listEnemy2.Count < this.quantityEnemy)
            {
                if (!this.listEnemy2.Contains(this.listEnemy[i]))
                {

                    this.listEnemy2.Add(this.listEnemy[i]);

                }
            }
        }
    }

    protected void ListLast()
    {
        for (int i = this.listEnemy.Count - 1; i >= 0; i--)
        {
            if (this.listEnemy2.Count < this.quantityEnemy)
            {
                if (!this.listEnemy2.Contains(this.listEnemy[i]))
                {

                    this.listEnemy2.Add(this.listEnemy[i]);

                }
            }
        }
    }

    protected virtual void CanAttack()
    {
        this.audioTowerAttack.AudioPlay();
        this.spawnBulletMagic.Spawn("bullet", this.pos, this.rot);

        this.timeCheckAttack = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (this.checkAddEnemy == true)
            {
                if (collision.transform.GetComponent<EnemyMovenment>().checkIce_2 == false) return;
            }

            if (!this.listEnemy.Contains(collision.transform.GetComponent<HpEnemy>()))
            {
                this.listEnemy.Add(collision.transform.GetComponent<HpEnemy>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            this.listEnemy.Remove(collision.transform.GetComponent<HpEnemy>());

            if (this.listEnemy2.Contains(collision.transform.GetComponent<HpEnemy>()))
            {
                this.listEnemy2.Remove(collision.transform.GetComponent<HpEnemy>());
            }
        }
    }

    
}
