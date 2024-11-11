using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : GapiMonoBehaviour
{
    public static LineController instance;
    [SerializeField] public LineRenderer lineRenderer;
    //[SerializeField] protected Transform particle;

    [SerializeField] public Attack attack;

    [SerializeField] protected Texture[] textures;

    [SerializeField] protected int animationStep;
    [SerializeField] protected float fps = 30f;
    [SerializeField] protected float fpsCount;

    [SerializeField] public Vector3 pos1;
    [SerializeField] public Vector3 pos;

    [SerializeField] public int positionCount = 0;

    protected override void Reset()
    {
        base.Reset();
        this.lineRenderer = GetComponent<LineRenderer>();
        this.attack = transform.GetComponent<Attack>();


        //this.particle = transform.parent.Find("Particle");
    }

    protected void OnEnable()
    {
        //this.lineRenderer.sortingOrder = 0;

        this.lineRenderer.SetPosition(0, transform.position);
        this.lineRenderer.SetPosition(1, transform.position);
    }

    protected override void Awake()
    {
        base.Awake();
        LineController.instance = this;
    }

    protected void Update()
    {
        this.LineAttack();

    }

    protected virtual void LineAttack()
    {
        if (this.attack.listEnemy.Count == 0 || this.pos == new Vector3(0, 0, 0))
        {
            this.lineRenderer.sortingOrder = 0;
            //this.lineRenderer.SetPosition(0, this.particle.position);
            //this.lineRenderer.SetPosition(1, this.particle.position);

            this.lineRenderer.SetPosition(0, transform.position);
            this.lineRenderer.SetPosition(1, transform.position);
            return;
        }
        this.lineRenderer.positionCount = this.positionCount;

        this.lineRenderer.sortingOrder = 6;

        this.pos1 = transform.position;
        this.pos1.y += 0.4f;
        this.pos1.z = 0;
        pos.z = 0;

        this.lineRenderer.SetPosition(0, pos1);
        this.lineRenderer.SetPosition(1, this.pos);


        this.fpsCount += Time.deltaTime;
        if (this.fpsCount >= 2f / this.fps)
        {
            this.animationStep++;
            if (this.animationStep == this.textures.Length) this.animationStep = 0;

            this.lineRenderer.material.SetTexture("_MainTex", this.textures[animationStep]);

            this.fpsCount = 0f;
        }
    }
}
