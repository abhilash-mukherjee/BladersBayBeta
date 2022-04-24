
using UnityEngine;

public abstract class StateAvailabilityAction : ScriptableObject
{
    public abstract void Act(StateController _stateController, State _state);
}
