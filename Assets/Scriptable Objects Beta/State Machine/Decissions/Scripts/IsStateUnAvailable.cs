using UnityEngine;

[CreateAssetMenu(fileName = "New Check If State Unavailable", menuName = "State Machine / Decissions / Check If State Unavailable")]
public class IsStateUnAvailable : Decission
{
    [SerializeField]
    BeyBladeStateAvailabilityEnum UnAvailable;
    public override bool Decide(StateController _stateCntroller, State _state)
    {
        if (_state.AvailabilityStatus.Name == UnAvailable)
        {
            Debug.Log($"{_state.Name} of {_stateCntroller.gameObject} is unavailable");
            return true;
        }
        else return false;
        
    }
}  