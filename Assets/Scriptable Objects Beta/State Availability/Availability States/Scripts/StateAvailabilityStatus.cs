
using System;
using UnityEngine;
[CreateAssetMenu(fileName ="new Availability Status", menuName = "State Availability / Availability Status")]
public class StateAvailabilityStatus : ScriptableObject
{
    [SerializeField]
    private BeyBladeStateAvailabilityEnum m_name;

    [SerializeField]
    private StateAvailabilityAction[] stateAvailabilityActions;
    [SerializeField]
    private StateAvailabilityTransition[] stateAvailabilityTransitions;

    public BeyBladeStateAvailabilityEnum Name { get => m_name;}
 
    public void UpdateStateAvailability(StateController _stateController, State _state)
    {
        DoActions(_stateController, _state);
        CheckTransitions(_stateController, _state);
    }

    private void CheckTransitions(StateController stateController, State state)
    {
        if (stateAvailabilityTransitions == null) return;
        if (stateAvailabilityTransitions.Length == 0) return;
        for (int i = 0; i < stateAvailabilityTransitions.Length; i++)
        {
            if (stateAvailabilityTransitions[i].AllDecissionsSucced(stateController, state))
            {
                stateController.RequestStateAvailabilityChange(state,stateAvailabilityTransitions[i].TrueState);
                break;
            }
            else stateController.RequestStateAvailabilityChange(state, stateAvailabilityTransitions[i].FalseState);
        }
    }

    private void DoActions(StateController _stateController, State _state)
    {
        if (stateAvailabilityActions == null) return;
        for (int i = 0; i < stateAvailabilityActions.Length; i++)
        {
            stateAvailabilityActions[i].Act(_stateController, _state);
        }
    }
}
