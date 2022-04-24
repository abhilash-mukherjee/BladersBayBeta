using UnityEngine;

[CreateAssetMenu(fileName = "New Display Effect Action", menuName = "State Machine / Actions /Display Effect")]
public class DisplayParticleEffect : BehaviourAction
{
    public override void Act(StateController _stateController, State _currentState)
    {
        foreach(var _state in _stateController.StateDict)
        {
            if(_state.Value.Effect != null)
            {
                if(_state.Value == _currentState)
                {
                    _state.Value.Effect.SetActive(true);
                }
                else
                {
                    _state.Value.Effect.SetActive(false);
                }
            }
        }
    }
}

