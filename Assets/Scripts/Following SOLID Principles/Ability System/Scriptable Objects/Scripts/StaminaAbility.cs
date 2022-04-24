using UnityEngine;

[CreateAssetMenu(fileName = "New Stamina Ability", menuName = "Ability System/Abilities/ Stamina Ability")]
public class StaminaAbility : DynamicAbilities

{
    public delegate void StaminaHandler(GameObject gameObject, BaseData defenceStats);
    public static event StaminaHandler OnStaminaAbilityActivated, OnStaminaAbilityExhausted, OnStaminaAbilityDeActivated;

   
    public override void UpdateAbility(GameObject obj, BaseData abilityStats)
    {
        if (abilityStats.IsAbilityLocked) return;
        if (abilityStats.IsActive) DepleteAbility(Time.deltaTime * abilityStats.AbilityDepletionRate, obj, abilityStats);
        else if (!abilityStats.IsActive && !abilityStats.IsReady) ReplenishAbility(Time.deltaTime * abilityStats.AbilityReplenishmentRate, obj, abilityStats);
    }

    protected override void InvokeActivationEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnStaminaAbilityActivated?.Invoke(beyBlade, abilityData);
    }

    protected override void InvokeDeactivationEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnStaminaAbilityDeActivated?.Invoke(beyBlade, abilityData);
    }
    public void IncreaseHealth(FloatVariable healthPoint, BaseData abilityData)
    {
        if(!abilityData.IsAbilityLocked && abilityData.IsActive)
        healthPoint.Value += abilityData.StaminaValue;
    }
    protected override void InvokeExhaustionEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnStaminaAbilityExhausted?.Invoke(beyBlade, abilityData);
    }
} 