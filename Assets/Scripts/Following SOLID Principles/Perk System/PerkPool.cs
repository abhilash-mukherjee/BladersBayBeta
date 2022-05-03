using System.Collections.Generic;
using UnityEngine;

public abstract class PerkPool : MonoBehaviour
{
    public delegate void PerkPoolHandler(List<IPerk> generatedPerks, PerkMessege perkMessege);
    public static event PerkPoolHandler OnPerksGenerated;
    protected void RaisePerksGeneratedEvent(List<IPerk> generatedPerks, PerkMessege perkMessege)
    {
        OnPerksGenerated?.Invoke(generatedPerks, perkMessege);
    }
    public abstract void GeneratePerks();
    public enum PerkMessege { WINNING_PERK, LOOSING_PERK }


}

