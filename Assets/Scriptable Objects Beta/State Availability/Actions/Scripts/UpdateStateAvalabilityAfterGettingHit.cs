
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Update State Avalability After Getting Hit", menuName = "State Availability / Action / Update State Availability After Getting Hit")]
public class UpdateStateAvalabilityAfterGettingHit : StateAvailabilityAction
{
    private List<ColisionData> m_collisionDataList = new List<ColisionData>();
    [SerializeField]
    private BeyBladeStateAvailabilityEnum UnAvailable;
    [SerializeField]
    private BeyBladeStateName BalanceStateName;
    [SerializeField]
    private BeyBladeStateName DefenceStateName;

    private void OnEnable()
    {
        BeyBladeHealthManager.OnBeyBladeDamaged += OnRecievedDamage;
    }
    private void OnDisable()
    {
        BeyBladeHealthManager.OnBeyBladeDamaged -= OnRecievedDamage;
        m_collisionDataList.Clear();
        
    }
    public override void Act(StateController _stateController, State _state)
    {
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _stateController);
        if (_state.AvailabilityStatus.Name != UnAvailable)
            return;
        if(_dataFromList != null)
        {
            foreach(var _dictState in _stateController.StateDict)
            {
                if(_dictState.Value.Data.StateName == DefenceStateName)
                    _dictState.Value.Data.CurrentAvailabilityIndex +=  _dictState.Value.Data.StateReplenishmentRate;
            }
            m_collisionDataList.Remove(_dataFromList);
        }
    }

    public void OnRecievedDamage(StateController _stateController, float _collisionIndex)
    {
        if (_stateController.CurrentState.Name != BalanceStateName)
        {
            return;
        }
        var _Data = new ColisionData(_stateController, _stateController.CurrentState.Name, _collisionIndex);
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _Data.stateController);
        if (_dataFromList == null)
        {
            m_collisionDataList.Add(_Data);
        }
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
