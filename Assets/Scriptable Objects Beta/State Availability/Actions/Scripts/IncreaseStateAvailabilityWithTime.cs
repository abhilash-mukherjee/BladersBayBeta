
using UnityEngine;

[CreateAssetMenu(fileName = "new Increase State Availability With Time", menuName = "State Availability / Action / Increase State Availability With Time")]
public class IncreaseStateAvailabilityWithTime : StateAvailabilityAction
{
    [SerializeField]
    private BeyBladeStateAvailabilityEnum UnAvailable;
    [SerializeField]
    private BeyBladeStateName StaminaStateName;
    public override void Act(StateController _stateController, State _state)
    {
        if (_state.AvailabilityStatus.Name != UnAvailable)
            return;
        if (_state.Data.StateName == StaminaStateName)
            _state.Data.CurrentAvailabilityIndex += _state.Data.StateReplenishmentRate;
    }
}