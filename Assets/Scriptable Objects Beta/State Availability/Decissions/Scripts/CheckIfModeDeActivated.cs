
using UnityEngine;

[CreateAssetMenu(fileName = "New Check If Mode DeActivated", menuName = "State Availability / Decissions / Check If Mode DeActivated")]
public class CheckIfModeDeActivated : StateAvailabilityDecission
{
    public override bool Decide(StateController _stateController, State _state)
    {
        if(_stateController.CurrentState.Name != _state.Name)
        {
            _state.Data.CurrentAvailabilityIndex = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
