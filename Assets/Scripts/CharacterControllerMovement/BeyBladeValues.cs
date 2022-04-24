using System.Collections.Generic;
using UnityEngine;

public class BeyBladeValues: MonoBehaviour
{
    [SerializeField]
    private StateData[] stateValueList;
    public float AttackValue { get => m_currentState.AttackValue; }
    public float DefenceValue { get => m_currentState.DefenceValue;  }
    public float StaminaValue { get => m_currentState.StaminaValue;  }
    public float DamageValue { get => m_currentState.DamageValue; }
    public float Speed { get => m_currentState.Speed;  }
    private StateData m_currentState;
    private void Awake()
    {
        m_currentState = stateValueList[0];
    }

    private void OnEnable()
    {
        BeyBladeStateController.OnBeyBladeStateChanged += ChangeCurrentMode;
    }
    private void OnDisable()
    {
        BeyBladeStateController.OnBeyBladeStateChanged -= ChangeCurrentMode;
        
    }
    public void ChangeCurrentMode(BeyBladeStateName _newStateName, GameObject _gameObject)
    {
        if (_gameObject != gameObject)
        {
            return;
        }
        if (stateValueList == null)
            return;
        if (stateValueList.Length == 0)
            return;
        for (int i = 0; i < stateValueList.Length; i++)
        {
            if(stateValueList[i].StateName == _newStateName)
            {
                m_currentState = stateValueList[i];
            }
        }
    }
}