using UnityEngine;

[CreateAssetMenu(fileName = "New Atack Ability", menuName = "Ability System/Abilities/ Attack Ability")]
public class AttackAbility : DynamicAbilities 
{
    public delegate void AttackHandler(GameObject gameObject, BaseData attackStats);
    public static event AttackHandler OnAtackAbilityActivated, OnAttackAbilityExhausted, OnAttackAbilityDeActivated;
    public override void UpdateAbility(GameObject obj, BaseData abilityStats)
    {
        if (abilityStats.IsAbilityLocked) return;
        if (abilityStats.IsActive) DepleteAbility(Time.deltaTime * abilityStats.AbilityDepletionRate, obj, abilityStats);
        else if (!abilityStats.IsActive && !abilityStats.IsReady) ReplenishAbility(Time.deltaTime * abilityStats.AbilityReplenishmentRate, obj, abilityStats);
    }

    protected override void InvokeActivationEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnAtackAbilityActivated?.Invoke(beyBlade, (BaseData)abilityData);
    }

    protected override void InvokeDeactivationEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnAttackAbilityDeActivated?.Invoke(beyBlade, abilityData);
    }

    protected override void InvokeExhaustionEvent(GameObject beyBlade, BaseData abilityData)
    {
        OnAttackAbilityExhausted?.Invoke(beyBlade, abilityData);
    }
}
