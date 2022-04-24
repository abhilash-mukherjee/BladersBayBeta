using UnityEngine;

public abstract class BehaviourAction : ScriptableObject
{
    public abstract void Act(StateController _stateController, State _currentState);
}

