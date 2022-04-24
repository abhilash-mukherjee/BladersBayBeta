using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseData: ScriptableObject
{
    public abstract bool IsReady { get; set; }
    public abstract bool IsActive { get; set; }
    public abstract float Speed { get; }
    public abstract float DamageValue { get; }
    public abstract float AttackValue { get; }
    public abstract float StaminaValue { get; }
    public abstract float AvailabilityIndex { get; set; }
    public abstract float AbilityDepletionRate { get; }
    public abstract bool IsAbilityLocked { get; }
    public abstract float AbilityReplenishmentRate { get; }
    public abstract float MaxAvailabilityIndex { get; }
    
    public abstract AbilityName AbilityName { get; set; }
    protected abstract float M_Speed { get; set; }
    protected abstract float M_DamageValue { get; set; }
    protected abstract float M_AttackValue { get; set; }
    protected abstract float M_StaminaValue { get; set; }
    protected abstract float M_AbilityDepletionRate { get; set; }
    protected abstract float M_AbilityReplenishmentRate { get; set; }
    protected abstract bool M_IsAbilityLocked { get; set; }
    public abstract void SetValues(BaseData abilityStat);

}
