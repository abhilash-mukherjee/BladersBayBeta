
using UnityEngine;

[CreateAssetMenu(fileName = "New Compare If SAI IsLess Than Zero", menuName = "State Availability / Decissions / Compare If SAI IsLess Than Zero")]
public class CompareIfSAIIsLessThanMinSAI : StateAvailabilityDecission
{
    public override bool Decide(StateController _stateController, State _state)
    {
        if (_state.Data.CurrentAvailabilityIndex <= _state.Data.MinimumStateAvailabiltyIndex) return true;
        else return false;
    }
}
