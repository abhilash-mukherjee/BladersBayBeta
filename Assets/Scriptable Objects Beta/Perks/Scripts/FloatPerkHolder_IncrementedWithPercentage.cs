using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Float Perk Holder Incremented With Percentage", menuName = "Perk Holders/ Float Perk Holders / Incremented With Percentage")]
public class FloatPerkHolder_IncrementedWithPercentage : FloatPerkHolder
{
    [SerializeField]
    private List<FloatPerk_IncrementedWithPercentage> floatPerks_IncrementedWithPercentage = new List<FloatPerk_IncrementedWithPercentage>();
    public override bool RedeemAllPerks()
    {
        if (CoinsRequiredToUnlock <= PlayerCoinCount.Value)
        {
            foreach (var _perk in floatPerks_IncrementedWithPercentage)
            {
                _perk.Redeem();
            }
            PlayerCoinCount.Value -= CoinsRequiredToUnlock;
            return true;
        }
        return false;
    }
}
