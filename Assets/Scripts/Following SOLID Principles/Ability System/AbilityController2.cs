using UnityEngine;

public abstract class AbilityController2 : MonoBehaviour
{
    public delegate void AbilityAddRemoveHandler(GameObject obj, BaseData abilityStat);
    public static event AbilityAddRemoveHandler OnAbilityAdded, OnAbilityRemoved;
    protected void RaiseAbilityAddedEvent(GameObject obj, BaseData abilityStat)
    {
        OnAbilityAdded?.Invoke(obj, abilityStat);
    }
    protected void RaiseAbilityRemovedEvent(GameObject obj, BaseData abilityStat)
    {
        OnAbilityRemoved?.Invoke(obj, abilityStat);
    }
}
