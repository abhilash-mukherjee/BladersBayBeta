using UnityEngine;

public class BattleStartAnimationEventManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent onMAtchStarted;
    public void PlaySound(string soundName)
    {
        GameAudioManager.Instance.PlaySoundOneShot(soundName);
    }
    public void RaiseMAtchStartedEvent()
    {
        onMAtchStarted.Raise();
    }
}
