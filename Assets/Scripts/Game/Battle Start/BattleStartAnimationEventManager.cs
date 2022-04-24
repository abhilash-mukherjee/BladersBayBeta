using UnityEngine;

public class BattleStartAnimationEventManager : MonoBehaviour
{
    public void PlaySound(string soundName)
    {
        GameAudioManager.Instance.PlaySoundOneShot(soundName);
    }
}
