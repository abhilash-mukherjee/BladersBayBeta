
using UnityEngine;

[CreateAssetMenu(fileName = "New Check If Mode Activated", menuName = "State Availability / Decissions / Check If Mode Activated")]
public class CheckIfModeActivated : StateAvailabilityDecission
{
    public override bool Decide(StateController _stateController, State _state)
    {
        if(_stateController.CurrentState.Name == _state.Name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
