
using UnityEngine;

public abstract class StateAvailabilityDecission : ScriptableObject
{
    public abstract bool Decide(StateController _stateController, State _state);
}
