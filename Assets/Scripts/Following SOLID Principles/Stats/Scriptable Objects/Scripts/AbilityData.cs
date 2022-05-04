using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Data", menuName = "Ability System/ Data")]
public class AbilityData : BaseData
{
    [SerializeField]
    private float speed, attackValue, dmgValue, staminaValue, depletionRate, replenishmentRate, maxAvailabilityIndex;
    [SerializeField]
    private bool isAbilityLocked;
    [SerializeField]
    private AbilityName abilityName;
    public override float Speed { get=>speed; }
    public override float DamageValue { get=>dmgValue; }
    public override float AttackValue { get=>attackValue; }
    public override float StaminaValue { get=>staminaValue; }
    public override bool IsAbilityLocked { get => isAbilityLocked; }
    public override float AvailabilityIndex
    {
        get => availabilityIndex;
        set
        {
            availabilityIndex = value > 1 ? 1 : (value < 0f ? 0f : value);
            m_isReady = availabilityIndex == 1;
        }
    }
    public override bool IsReady { get => m_isReady; set => m_isReady = value; }
    public override bool IsActive { get => m_isActive; set => m_isActive = value; }
    public override float AbilityDepletionRate { get => depletionRate; }
    public override float AbilityReplenishmentRate { get => replenishmentRate; }
    public override float MaxAvailabilityIndex { get => maxAvailabilityIndex; }
    public override AbilityName AbilityName { get => abilityName; set => abilityName = value; }
    

    protected override float M_Speed { get=>speed; set=>speed = value; }
    protected override float M_DamageValue { get => dmgValue; set=>dmgValue = value; }
    protected override float M_AttackValue { get=>attackValue; set=>attackValue = value; }
    protected override float M_StaminaValue { get=>staminaValue; set=>staminaValue = value; }
    protected override bool M_IsAbilityLocked { get => isAbilityLocked; set => isAbilityLocked = value; }
    protected override float M_AbilityDepletionRate { get => depletionRate; set => depletionRate = value; }
    protected override float M_AbilityReplenishmentRate { get => replenishmentRate; set => replenishmentRate = value; }


    private float availabilityIndex;
    private bool m_isReady, m_isActive;
    public override void SetValues(BaseData baseData)
    {
        M_Speed = baseData.Speed;
        M_AttackValue = baseData.AttackValue;
        M_DamageValue = baseData.DamageValue;
        M_IsAbilityLocked = baseData.IsAbilityLocked;
        M_StaminaValue = baseData.StaminaValue;
        AbilityName = baseData.AbilityName;
    }
}
