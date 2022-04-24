using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionSoundManager : MonoBehaviour
{
  

    private void OnEnable()
    {
        CollisionChecker.OnAudioPlayed += PlayCollisionAudio;
    }

    private void OnDisable()
    {
        CollisionChecker.OnAudioPlayed -= PlayCollisionAudio;
        
    }
    protected abstract void PlayCollisionAudio(ICollision collision);

}
