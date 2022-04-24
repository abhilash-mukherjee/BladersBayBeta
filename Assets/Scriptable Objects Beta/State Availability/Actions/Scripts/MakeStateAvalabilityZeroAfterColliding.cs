
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Update State Avalability After Colliding", menuName = "State Availability / Action / Update State Availability After Colliding")]
public class MakeStateAvalabilityZeroAfterColliding : StateAvailabilityAction
{
    private List<ColisionData> m_collisionDataList = new List<ColisionData>();
    [SerializeField]
    private BeyBladeStateName StaminaStateName;

    private void OnEnable()
    {
        BeyBladeHealthManager.OnBeyBladeCollided += OnCollided;
    }
    private void OnDisable()
    {
        BeyBladeHealthManager.OnBeyBladeCollided -= OnCollided;
        m_collisionDataList.Clear();
    }
    public override void Act(StateController _stateController, State _state)
    {
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _stateController);
        if(_dataFromList != null)
        {
            if (_state.Data.StateName == StaminaStateName)
            {
                _state.Data.CurrentAvailabilityIndex = 0f;
                m_collisionDataList.Remove(_dataFromList);
            }
        }
    }  

    public void OnCollided(StateController _stateController, float _collisionIndex)
    {
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
