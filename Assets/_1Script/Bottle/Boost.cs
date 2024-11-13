using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost : GapiMonoBehaviour
{
    [SerializeField] protected Transform prefab;

    public List<Transform> listTower;
    public List<Attack> listAttack;
    public List<Transform> listBuff;

    public float sumDamager = 2;

    [SerializeField] protected float timeBoost = 7f;
    [SerializeField] protected float timeCount = 0f;

    public bool checkBoost = false;

    public bool checkListEmpty = false;

    [SerializeField] protected AudioSource audioSource;

    protected override void Reset()
    {
        base.Reset();

        this.prefab = GameObject.Find("Tower").transform.Find("Holder");
        this.sumDamager = 2;

        this.audioSource = GetComponent<AudioSource>();
    }

    protected void OnEnable()
    {
        this.audioSource.Play();
        this.sumDamager = MainScore.instance.LoadFloat("parameterBoost", 2);

        this.TowerBoost();

        if (this.listTower.Count == 0) this.checkBoost = false;
    }

    protected void Update()
    {
        if (this.listTower.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }

        this.checkBoost = true;
        this.DisableBoost();
    }

    public void AddTower()
    {
        foreach (Transform child in this.prefab)
        {
            if (child.gameObject.activeSelf)
            {
                
                this.listTower.Add(child);
                this.listAttack.Add(child.transform.Find("Attack").GetComponent<Attack>());
                this.listBuff.Add(child.gameObject.transform.Find("Buff"));
            }
            
        }

        if (this.listTower.Count == 0)
        {
            this.checkListEmpty = true;
        }
        else this.checkListEmpty = false;
    }

    public void TowerBoost()
    {
        if (this.listTower.Count == 0) return;

        for (int i = 0; i < this.listTower.Count; i++)
        {
            this.listAttack[i].damage *= this.sumDamager;
            this.listBuff[i].gameObject.SetActive(true);
        }
    }

    protected void DisableBoost()
    {
        this.timeCount += Time.deltaTime;
        if (this.timeCount < this.timeBoost) return;
        
        for (int i = 0; i < this.listTower.Count; i++)
        {
            this.listAttack[i].damage /= this.sumDamager;
            this.listBuff[i].gameObject.SetActive(false);
        }

        this.checkBoost = false;
        this.timeCount = 0;

        this.listTower.Clear();
        this.listBuff.Clear();
        this.listAttack.Clear();

        gameObject.SetActive(false);
    }
}
