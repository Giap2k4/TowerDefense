using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTowerAttack : GapiMonoBehaviour
{
    public static AudioTowerAttack instance;

    [SerializeField] protected AudioSource audioSource;

    protected override void Reset()
    {
        base.Reset();

        this.audioSource = GetComponent<AudioSource>();
    }

    protected override void Awake()
    {
        base.Awake();
        AudioTowerAttack.instance = this;
    }

    public virtual void AudioPlay()
    {
        this.audioSource.Play();
    }

    public virtual void AudioStop()
    {
        this.audioSource.Stop();
    }
}
