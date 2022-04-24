using UnityEngine;

public abstract class DynamicAbilities : Ability
{
    protected override void DepleteAbility(float _amt, GameObject obj, BaseData abilityStats)
    {
        if (abilityStats.AvailabilityIndex == 0f) return;
            abilityStats.AvailabilityIndex -= _amt;
        if (abilityStats.AvailabilityIndex == 0f)
            ExhaustAbility(obj, abilityStats);
    }


    public override void MakeAbilityReady(GameObject obj, BaseData abilityStats)
    {
        abilityStats.AvailabilityIndex = abilityStats.MaxAvailabilityIndex;
        abilityStats.IsReady = true;
    }

    public override void ReplenishAbility(float _amt, GameObject obj, BaseData abilityStats)
    {
        abilityStats.AvailabilityIndex += _amt;
    }
    public override void ActivateAbility(GameObject beyBlade, BaseData defenceData)
    {
        if (defenceData.IsReady && !defenceData.IsAbilityLocked)
        {
            defenceData.IsActive = true;
            defenceData.IsReady = false;
            InvokeActivationEvent(beyBlade, (BaseData)defenceData);
        }
    }
    public override void ExhaustAbility(GameObject obj, BaseData defenceData)
    {
        defenceData.AvailabilityIndex = 0f;
        defenceData.IsReady = false; 
        defenceData.IsActive = false;
        InvokeExhaustionEvent(obj, defenceData);
    }
    public override void DeactivateAbility(GameObject obj, BaseData abilityStats)
    {
        abilityStats.IsActive = false;
        InvokeDeactivationEvent(obj, abilityStats);
    }
    protected abstract void InvokeActivationEvent(GameObject beyBlade, BaseData abilityData);
    protected abstract void InvokeDeactivationEvent(GameObject beyBlade, BaseData abilityData);
    protected abstract void InvokeExhaustionEvent(GameObject beyBlade, BaseData abilityData);
}