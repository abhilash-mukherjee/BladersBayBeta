
using UnityEngine;

[System.Serializable]
public class State 
{
    public BeyBladeStateName Name;
    public StateBehaviour Behaviour;
    public StateData Data;
    public StateAvailabilityStatus AvailabilityStatus;
    public GameObject Effect;
}
