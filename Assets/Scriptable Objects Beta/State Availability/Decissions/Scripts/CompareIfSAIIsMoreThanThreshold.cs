
using UnityEngine;

[CreateAssetMenu(fileName = "New  Compare If SAI Is More Than Threshold", menuName = "State Availability / Decissions / Compare If SAI Is More Than Threshold")]
public class CompareIfSAIIsMoreThanThreshold : StateAvailabilityDecission
{
    public override bool Decide(StateController _stateController, State _state)
    {
        if (_state.Data.CurrentAvailabilityIndex >= _state.Data.ThresholdStateAvailabiltyIndex)
            return true;
        else return false;

    }
}
