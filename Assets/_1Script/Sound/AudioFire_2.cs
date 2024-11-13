using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFire_2 : AudioTowerAttack
{

    public override void AudioPlay()
    {
        //
        if (!audioSource.isPlaying)
        {
            this.audioSource.loop = true;
            this.audioSource.Play();
        }
            
    }
}
