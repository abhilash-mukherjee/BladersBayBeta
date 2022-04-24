using System.Collections.Generic;
using UnityEngine;

public class BeybladeModeBasedCollisionSoundManager : CollisionSoundManager
{
    [SerializeField]
    private AudioSource collisionAudioSource;
    [SerializeField]
    public List<Mode_ModeToMusicMapping> modeMusicMappings;

    protected override void PlayCollisionAudio(ICollision collision)
    {
        var mode1 = collision.Collidable1.CurrentStats.AbilityName;
        var mode2 = collision.Collidable2.CurrentStats.AbilityName;
        var audioEffectToPlay = modeMusicMappings.Find(p => (p.modes[0] == mode1 && p.modes[1] == mode2) || (p.modes[1] == mode1 && p.modes[0] == mode2)).audioeEffect;
        audioEffectToPlay.Play(collisionAudioSource);
    }
  
}
[System.Serializable]
public class Mode_ModeToMusicMapping
{
    public List<AbilityName> modes;
    public AudioEvent audioeEffect;
}
