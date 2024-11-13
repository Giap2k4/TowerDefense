using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : GapiMonoBehaviour
{
    [SerializeField] protected Transform holder;
    public List<Transform> listEnemy;
    public List<float> enemyVelocity;

    public float freezoTime = 0f;
    protected float timeCount = 0f;

    public bool checkListEmpty = false;

    protected AudioSource audioSource;


    protected override void Reset()
    {
        base.Reset();

        this.audioSource = GetComponent<AudioSource>();
        this.holder = GameObject.Find("Enemy").transform.Find("Holder");
    }

    protected void OnEnable()
    {
        this.audioSource.Play();
        this.freezoTime = MainScore.instance.LoadFloat("parameterFreeze", 3);
        this.FreezeEnemy();
    }

    protected void Update()
    {
        if (this.listEnemy.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        this.DisableFreeze();
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

    protected void FreezeEnemy()
    {
        if (this.listEnemy.Count == 0) return;

        for (int i = 0; i < this.listEnemy.Count; i++)
        {
            EnemyMovenment enemyMvm = this.listEnemy[i].GetComponent<EnemyMovenment>();

            this.enemyVelocity.Add(enemyMvm.speed);

            enemyMvm.speed = 0;
            enemyMvm.checkFreeze = true;
            enemyMvm.animator.speed = 0;
            enemyMvm.GetComponent<SpriteRenderer>().color = new Color(0, 0.8f, 1, 0.8f);
            // Chuyển màu sang đóng băng
        }
    }

    protected void DisableFreeze()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.freezoTime) return;

        for (int i = 0; i < this.listEnemy.Count; i++)
        {
            EnemyMovenment enemyMvm = this.listEnemy[i].GetComponent<EnemyMovenment>();

            enemyMvm.speed = this.enemyVelocity[i];
            enemyMvm.checkFreeze = false;
            enemyMvm.animator.speed = 1;
            // Chuyển màu sang bình thường
            if (!enemyMvm.checkIce_2)
            {
                enemyMvm.GetComponent<SpriteRenderer>().color = new Color(1f, 0.6f, 1f, 1f);
            } 
            else enemyMvm.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }

        this.timeCount = 0;
        this.listEnemy.Clear();
        this.enemyVelocity.Clear();

        gameObject.SetActive(false);
    }

}
