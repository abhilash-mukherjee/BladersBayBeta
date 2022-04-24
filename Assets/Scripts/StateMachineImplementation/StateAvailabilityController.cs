using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BeyBladeStateController))]
public class StateAvailabilityController : MonoBehaviour
{
    [SerializeField]
    private List<StateBehaviour> StateList = new List<StateBehaviour>();
    [SerializeField]
    private List<StateName_StateValueMapping> stateName_StateValueMappings = new List<StateName_StateValueMapping>();
    private void Update()
    {
        
    }

    public StateData GetStateValue(StateBehaviour _state)
    {
        var sVM = stateName_StateValueMappings.Find(p => p.StateName == _state.StateName);
        if (sVM == null) return null;
        else return sVM.StateValues;
    }
    [System.Serializable]
    public class StateName_StateValueMapping
    {
        public BeyBladeStateName StateName;
        public StateData StateValues;
    }
}