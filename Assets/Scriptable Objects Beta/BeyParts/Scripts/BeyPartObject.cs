
using UnityEngine;

public abstract class BeyPartObject : ScriptableObject
{
    public float attackValue;
    public float defenceValue;
    public float staminaValue;
    public float speedValue;
    public BeyPartTag partTag;
    public string uID;
    public string description;

    public void UpgradePartValues(float attackChange, float defenceChange, float staminaChange, float speedChange)
    {
        attackValue += attackChange;
        defenceValue += defenceChange;
        staminaValue += staminaChange;
        speedValue += speedChange;
    }
}

public enum BeyPartTag
{
    ENERGY_LAYER, FORGE_DISC, PERFORMANCE_TIP
}


