using UnityEngine;
public abstract class Ability : ScriptableObject
{
    public abstract void ExhaustAbility(GameObject obj, BaseData abilityStats);
    public abstract void DeactivateAbility(GameObject obj, BaseData abilityStats);
    public abstract void UpdateAbility(GameObject obj, BaseData abilityStats);
    public abstract void ReplenishAbility(float _amt, GameObject obj, BaseData abilityStats);
    protected abstract void DepleteAbility(float _amt, GameObject obj, BaseData abilityStats);
    public abstract void MakeAbilityReady(GameObject obj, BaseData abilityStats);
    public abstract void ActivateAbility(GameObject obj, BaseData abilityStats);
}
