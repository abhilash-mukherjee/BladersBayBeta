using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New State", menuName = "State Machine / State")]
public class StateBehaviour : ScriptableObject
{

    [SerializeField]
    protected BehaviourAction[] behavioueActions;
    [SerializeField]
    protected StateTransition[] stateTransitions;
    [SerializeField]
    protected BeyBladeStateName stateName;
    [SerializeField]
    private Color sceneGizmoColor = Color.gray;
    public BeyBladeStateName StateName { get => stateName; }

    public Color SceneGizmoColor { get => sceneGizmoColor; }
     
    public void UpdateBehaviour(StateController _stateController, State _currentState)
    {
        ShowBehaviour(_stateController, _currentState);
        CheckStateTransitions(_stateController, _currentState);
    }

    private void ShowBehaviour(StateController _stateController, State _currentState)
    {
        if (behavioueActions == null) return;
        if (behavioueActions.Length == 0) return;
        for (int i = 0; i < behavioueActions.Length; i++) behavioueActions[i].Act(_stateController, _currentState);
    }

    private void CheckStateTransitions(StateController _stateController, State _CurrentState)
    {
        if (stateTransitions == null) return;
        if (stateTransitions.Length == 0) return;
        for (int i = 0; i < stateTransitions.Length; i++)
        {
            if (stateTransitions[i].AllDecissionsSucced(_stateController, _CurrentState))
            {
                _stateController.RequestStateChange(stateTransitions[i].TrueStateName);
                break;
            }
            else _stateController.RequestStateChange(stateTransitions[i].FalseStateName);
        }
    }

}
