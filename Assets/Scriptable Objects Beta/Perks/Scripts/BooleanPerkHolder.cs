using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Boolean Perk Holder", menuName = "Perk Holders/ boolean perk holder")]
public class BooleanPerkHolder : PerkHolder
{
    [SerializeField]
    private List<BooleanPerk> booleanPerks;
    public override bool RedeemAllPerks()
    {

        if (CoinsRequiredToUnlock <= PlayerCoinCount.Value)
        {
            foreach (var _perk in booleanPerks)
            {
                _perk.Redeem();
            }
            PlayerCoinCount.Value -= CoinsRequiredToUnlock;
            return true;
        }
        else return false;
    }
}
