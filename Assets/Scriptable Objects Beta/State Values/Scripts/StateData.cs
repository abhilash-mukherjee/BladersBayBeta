
using UnityEngine;

[CreateAssetMenu(fileName = "New State Values", menuName = "State Machine / State Values")]
public class StateData : ScriptableObject
{
    [SerializeField]
    private BeyBladeStateName stateName;
    [SerializeField]
    private BoolVariable isLocked;
    [SerializeField]
    protected FloatVariable attackValue;
    [SerializeField]
    protected FloatVariable defenceValue;
    [SerializeField]
    protected FloatVariable staminaValue;
    [SerializeField]
    protected FloatVariable damageValue;
    [SerializeField]
    protected FloatVariable speed;
    [SerializeField]
    private FloatVariable stateReplenishmentRate;
    [SerializeField]
    private FloatVariable stateDepletionRate;
    [SerializeField]
    private FloatVariable startingStateAvailabiltyIndx, thresholdStateAvailabiltyIndex, minimumStateAvailabiltyIndex;

    private float m_currentAvailabilityIndex;

    public float StateReplenishmentRate { get => stateReplenishmentRate.Value; }
    public float StateDepletionRate { get => stateDepletionRate.Value; }
    public float AttackValue { get => attackValue.Value; }
    public float DefenceValue { get => defenceValue.Value; }
    public float StaminaValue { get => staminaValue.Value; }
    public float DamageValue { get => damageValue.Value; }
    public float Speed { get => speed.Value; }
    public BeyBladeStateName StateName { get => stateName; }
    public float CurrentAvailabilityIndex 
    { 
        get => m_currentAvailabilityIndex;
        set
        {
            if (value <= 0f) 
            { 
                m_currentAvailabilityIndex = 0f; 
                return; 
            }
            else if (value >= thresholdStateAvailabiltyIndex.Value) 
            { 
                m_currentAvailabilityIndex = thresholdStateAvailabiltyIndex.Value; 
                return; 
            }
            m_currentAvailabilityIndex = value;
        }
    }
    public float ThresholdStateAvailabiltyIndex { get => thresholdStateAvailabiltyIndex.Value;  }
    public float MinimumStateAvailabiltyIndex { get => minimumStateAvailabiltyIndex.Value; }
    public bool IsLocked { get => isLocked.Value; set => isLocked.Value = value; }

    private void OnEnable()
    {
        m_currentAvailabilityIndex = startingStateAvailabiltyIndx.Value;
    }
    
    private void OnDisable()
    {
        m_currentAvailabilityIndex = startingStateAvailabiltyIndx.Value;
    }

    
  
}
