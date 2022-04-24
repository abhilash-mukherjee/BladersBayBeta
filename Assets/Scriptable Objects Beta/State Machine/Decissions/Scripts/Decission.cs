using UnityEngine;

public abstract class Decission : ScriptableObject
{
    public abstract bool Decide(StateController _stateCntroller, State _state);
}
