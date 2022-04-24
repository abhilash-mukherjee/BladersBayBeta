using UnityEngine;

public abstract class AbilityController: MonoBehaviour
{
    public delegate void AbilityAddRemoveHandler(GameObject obj, BaseData abilityStat, Ability ability);
    public static event AbilityAddRemoveHandler OnAbilityAdded, OnAbilityRemoved;
    protected abstract void DeActivateVFX(GameObject gameObject, BaseData attackStats);
    protected abstract void ActivateVFX(GameObject gameObject, BaseData attackStats);
    protected abstract void SwitchToAbilityStats(GameObject gameObject, BaseData attackStats);
    protected abstract void SwitchToNormalStats(GameObject gameObject, BaseData attackStats);
    protected void RaiseAbilityAddedEvent(GameObject obj, BaseData abilityStat, Ability ability)
    {
        OnAbilityAdded?.Invoke(obj, abilityStat, ability);
    }
    protected void RaiseAbilityRemovedEvent(GameObject obj, BaseData abilityStat, Ability ability)
    {
        OnAbilityRemoved?.Invoke(obj, abilityStat, ability);
    }
}