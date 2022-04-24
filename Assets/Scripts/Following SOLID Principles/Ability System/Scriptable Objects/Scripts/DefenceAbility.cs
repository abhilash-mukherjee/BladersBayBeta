using UnityEngine;
[CreateAssetMenu(fileName = "New Defence Ability", menuName = "Ability System/Abilities/ Defence Ability")]
public class DefenceAbility : DynamicAbilities 

{
    public delegate void DefenceHandler(GameObject gameObject, BaseData defenceStats);
    public static event DefenceHandler OnDefenceAbilityActivated, OnDefenceAbilityDeActivated, OnDefenceAbilityExhausted;

   
    public override void UpdateAbility(GameObject obj, BaseData abilityStats)
    {
        if (abilityStats.IsAbilityLocked) return;
        if (abilityStats.IsActive) DepleteAbility(Time.deltaTime * abilityStats.AbilityDepletionRate, obj, abilityStats);
        else if (!abilityStats.IsActive && !abilityStats.IsReady) ReplenishAbility(Time.deltaTime * abilityStats.AbilityReplenishmentRate, obj, abilityStats);
    }

    protected override void InvokeActivationEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnDefenceAbilityActivated?.Invoke(beyBlade, abilityData);
    }

    protected override void InvokeDeactivationEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnDefenceAbilityDeActivated?.Invoke(beyBlade, abilityData);
    }

    protected override void InvokeExhaustionEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnDefenceAbilityExhausted?.Invoke(beyBlade, abilityData);
    }
} 
