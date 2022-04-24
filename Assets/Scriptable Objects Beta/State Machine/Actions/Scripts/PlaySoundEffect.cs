using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Effect", menuName = "State Machine / Actions /play sound Effect")]
public class PlaySoundEffect : BehaviourAction
{
    [SerializeField]
    private string soundName = "Wind";
    public override void Act(StateController _stateController, State _currentState)
    {
        if (!GameAudioManager.Instance.IsSoundPlaying(soundName))
            GameAudioManager.Instance.PlaySoundOneShot(soundName);
    }
}

