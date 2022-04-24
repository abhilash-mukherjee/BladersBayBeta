using System;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField]
    StateDictionaryHolder stateDictHolder;
    [SerializeField]
    private BeyBladeStateName StartingState, BalanceStateName;
    [SerializeField][Tooltip("The Enum Which Tells That a state is available")]
    private BeyBladeStateAvailabilityEnum StateIsAvailable;
    private Dictionary<BeyBladeStateName, State> m_stateDict;
    private State m_currentState;

    public Dictionary<BeyBladeStateName, State> StateDict { get => m_stateDict; }
    public State CurrentState { get => m_currentState; }

    private void Start()
    {
        Debug.Log("Lorem Ipsum  skjdfjnsdfndsj");
        stateDictHolder.CustomAwake();
        Debug.Log( "Dictionary" +  stateDictHolder.StateDictionary.Keys.Count);
        m_stateDict = stateDictHolder.StateDictionary;
        if (m_stateDict == null)
            Debug.LogError("State Dict is not set to an instance of stateDict");
        m_currentState = m_stateDict[StartingState];
        Debug.Log(m_stateDict[StartingState]);
        if (m_currentState == null)
            Debug.LogError("Current State is not set to an instance of State");
    }

    private void Update()
    {
        m_currentState.Behaviour.UpdateBehaviour(this, m_currentState);
        UpdateAllStateAvailabilities();
    }

    private void UpdateAllStateAvailabilities()
    {
        foreach(var _state in m_stateDict)
        {
            _state.Value.AvailabilityStatus.UpdateStateAvailability(this, _state.Value);
        }
    }

    public void RequestStateChange(BeyBladeStateName _newStateName)
    {
        if (!m_stateDict.ContainsKey(_newStateName))
            return;
        var _newState = m_stateDict[_newStateName];
        if (_newState == null) return;
        if(_newState.AvailabilityStatus.Name == StateIsAvailable)
        {
            m_currentState = _newState;
        }
        else
        {
            Debug.Log($"{_newStateName} of {this.gameObject} is not available");
        }
    }
    public void RequestStateAvailabilityChange(State _state, StateAvailabilityStatus _newAvailabilityStatus)
    {
        var _dictState = m_stateDict[_state.Name];
        if (_dictState == null) return;
        else
        {
            if(_state.AvailabilityStatus == _newAvailabilityStatus || _state.Name == BalanceStateName)
            {
                return;
            }
            Debug.Log($"Availbility of {_state.Name} of {gameObject} is changed from \"{_dictState.AvailabilityStatus.Name}\" to \"{_newAvailabilityStatus.Name} \"");
            _dictState.AvailabilityStatus = _newAvailabilityStatus;
        }
    }
}