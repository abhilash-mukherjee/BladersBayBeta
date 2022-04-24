
using UnityEngine;

[CreateAssetMenu(fileName = "new Reduce State Availability With Time", menuName = "State Availability / Action / Reduce State Availability With Time")]
public class ReduceStateAvailabilityWithTime : StateAvailabilityAction
{
    public override void Act(StateController _stateController, State _currentState)
    {

        _currentState.Data.CurrentAvailabilityIndex -= _currentState.Data.StateDepletionRate;
    }
}
