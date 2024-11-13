using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBtn : GapiMonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    protected override void Reset()
    {
        base.Reset();
        this.audioSource = GetComponent<AudioSource>();
    }
    public void AudioPlay()
    {
        this.audioSource.Play();
    }
}
