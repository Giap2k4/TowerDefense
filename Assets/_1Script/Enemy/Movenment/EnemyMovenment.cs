using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovenment : GapiMonoBehaviour
{
    [SerializeField] public Animator animator;

    [SerializeField] protected EnemySO enemySO;
    [SerializeField] protected string nameSO;
    [SerializeField] protected MapSO mapSO;
    [SerializeField] protected string nameMap;

    [SerializeField] public List<Vector3> posSpawn;
    //public static List<Vector3> posSpawn;

    [SerializeField] public int counter = 0;

    [SerializeField] public float speed = 0;
    [SerializeField] public float speedFirst = 0;

    [SerializeField] public float timeLine = 1f;
    [SerializeField] protected float timeCount = 0;

    [SerializeField] public bool checkIce_2 = true;

    [SerializeField] public bool checkFreeze = false;
    [SerializeField] public bool checkPause = false;

    [SerializeField] protected HpEnemy hpEnemy; 

    protected override void Reset()
    {
        this.animator = GetComponent<Animator>();

        this.enemySO = Resources.Load<EnemySO>(this.nameSO);
        this.speed = this.enemySO.speed;
        this.speedFirst = this.enemySO.speed;

        this.hpEnemy = GetComponent<HpEnemy>();

    }
    protected override void Awake()
    {
        base.Awake();
        this.nameMap = ScrollLevel.nameMap;
        this.mapSO = Resources.Load<MapSO>("Map_" + this.nameMap);

        posSpawn = new List<Vector3>(this.mapSO.listCounter);
    }


    protected void OnEnable()
    {
        this.counter = 0;

        this.animator.speed = 1;
        this.speed = this.speedFirst;

        this.checkIce_2 = true;
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    protected void FixedUpdate()
    {
        this.Movenment();
        this.CheckVelocity();
    }

    protected void Movenment()
    {
        
        if (this.counter == posSpawn.Count - 1) return;

        Vector3 pos = (posSpawn[counter + 1] - transform.position).normalized;
        pos.z = 0;

        transform.position = Vector3.MoveTowards(transform.position, posSpawn[counter + 1], this.speed * Time.deltaTime);

        if (Mathf.Abs(pos.x) > Mathf.Abs(pos.y))
        {
            if (pos.x > 0.1f)
            {
                this.animator.Play("Right");
            } else
            {
                this.animator.Play("Left");
            }
        } else
        {
            if (pos.y > 0.1f)
            {
                this.animator.Play("Up");
            }
            else
            {
                this.animator.Play("Down");
            }
        }

        if (transform.position == posSpawn[counter + 1])
        {
            this.counter++;

            if (this.counter == posSpawn.Count - 1)
            {
                HealthLevel.instance.CheckHealth(1);

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
    }


    protected void CheckVelocity()
    {
        if (this.checkFreeze || this.checkPause || this.speed >= this.speedFirst) return;

        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeLine) return;

        this.speed = this.speedFirst;
        this.timeCount = 0;
    }

}
