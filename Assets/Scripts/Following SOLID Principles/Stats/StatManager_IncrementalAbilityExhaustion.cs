using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StatManager_IncrementalAbilityExhaustion : StatManager
{   

    protected override void OnStatAdded(GameObject _gameObject,BaseData newStat, Ability newAbility)
    {
        if (_gameObject != this.gameObject) return;
        if ( CurrentAbilityStatMapping == null || CurrentAbilityStatMapping.ability == null || CurrentAbilityStatMapping.abilityData == null)
        {
            CurrentAbilityStatMapping = new AbilityStatMapping(newAbility, newStat);
            m_CurrentStats.SetValues(newStat);
            return;
        }
        if (CurrentAbilityStatMapping.ability == newAbility && CurrentAbilityStatMapping.abilityData == newStat) return;
        var lastAbility = CurrentAbilityStatMapping.ability;
        var lastAbilityData = CurrentAbilityStatMapping.abilityData;
        lastAbility.DeactivateAbility(gameObject, lastAbilityData);
        CurrentAbilityStatMapping = new AbilityStatMapping(newAbility, newStat);
        m_CurrentStats.SetValues(newStat);
    }
    protected override void OnStatRemoved(GameObject _gameObject, BaseData oldStat, Ability oldAbility)
    {
        if (_gameObject != this.gameObject) return;
        if (CurrentAbilityStatMapping == null)
        {
            m_CurrentStats.SetValues(m_BalanceStats);
            return;
        }
        if (CurrentAbilityStatMapping.abilityData == oldStat)
        {
            CurrentAbilityStatMapping = null;
            m_CurrentStats.SetValues(m_BalanceStats);
        }
    }
    
}

[System.Serializable]
public class AbilityStatMapping
{
    public Ability ability;
    public BaseData abilityData;
    public AbilityStatMapping(Ability ability, BaseData abilityData)
    {
        this.ability = ability;
        this.abilityData = abilityData;
    }
}
