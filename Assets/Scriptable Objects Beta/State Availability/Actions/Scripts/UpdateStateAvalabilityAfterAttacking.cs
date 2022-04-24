
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Update State Avalability After Attacking", menuName = "State Availability / Action / Update State Availability After Attacking")]
public class UpdateStateAvalabilityAfterAttacking : StateAvailabilityAction
{
    private List<ColisionData> m_collisionDataList = new List<ColisionData>();
    [SerializeField]
    private BeyBladeStateAvailabilityEnum UnAvailable;
    [SerializeField]
    private BeyBladeStateName BalanceStateName;
    [SerializeField]
    private BeyBladeStateName AttackStateName;

    private void OnEnable()
    {
        BeyBladeHealthManager.OnBeyBladeAttacked += OnAttacked;
    }
    private void OnDisable()
    {
        BeyBladeHealthManager.OnBeyBladeAttacked -= OnAttacked;
        m_collisionDataList.Clear();
        
    }
    public override void Act(StateController _stateController, State _state)
    {
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _stateController);
        if (_state.AvailabilityStatus.Name != UnAvailable)
        {
            return;
        }
        if(_dataFromList != null)
        {
            Debug.Log("Length of _dataList = " + m_collisionDataList.Count);
            Debug.Log($"Going inside for loop. Current data from list =  {_dataFromList.stateController}, {_dataFromList.stateName}, {_dataFromList.CollisionIndex}");
            foreach(var _dictState in _stateController.StateDict)
            {
                Debug.Log($"Found the state controller of  {_stateController.gameObject} in collision data list");
                Debug.Log($"This state is {_dictState.Value.Data.StateName} of {_stateController.gameObject}");
                if (_dictState.Value.Data.StateName == AttackStateName)
                {
                    Debug.Log($"CurrentAvailabilityIndex of {_state.Name} of {_stateController.gameObject} is updted");
                    _dictState.Value.Data.CurrentAvailabilityIndex += _dictState.Value.Data.StateReplenishmentRate;
                    m_collisionDataList.Remove(_dataFromList);
                }
            }
        }
        else 
        { 
            Debug.Log("No data found in the collision data list with gameOject = " + _stateController.gameObject);
            Debug.Log("Length of _dataList = " + m_collisionDataList.Count);
        }
    }

    public void OnAttacked(StateController _stateController, float _collisionIndex)
    {
        Debug.Log($"On Attacked Called of {_stateController.gameObject}");
        if (_stateController.CurrentState.Name != BalanceStateName)
        { 
            return;
        }
        var _Data = new ColisionData(_stateController, _stateController.CurrentState.Name, _collisionIndex);
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _Data.stateController); 
        if (_dataFromList == null)
        {
            Debug.Log("Recent collision dta upadated");
            Debug.Log($"Collision Data Object : {_Data.stateController}, {_Data.stateName}, {_Data.CollisionIndex}");
            m_collisionDataList.Add(_Data);
        }
        else 
            Debug.Log("Recent collision data NOT upadated");
    }

    private class ColisionData
    {
        public StateController stateController;
        public BeyBladeStateName stateName;
        public float CollisionIndex;
        public ColisionData(StateController _stateController, BeyBladeStateName _stateName, float _CollisionIndex)
        {
            stateController = _stateController;
            stateName = _stateName;
            CollisionIndex = _CollisionIndex;
        }
    }
}
