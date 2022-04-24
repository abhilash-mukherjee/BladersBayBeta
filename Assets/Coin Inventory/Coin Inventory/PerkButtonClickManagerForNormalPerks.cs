using UnityEngine;

public class PerkButtonClickManagerForNormalPerks : PerkButtonClickManager
{
    public override void RedeemButtonClicked()
    {
        if (PerkHolder.RedeemAllPerks())
        {
            if (RedeemSuccededPanel != null)
            {
                PerkPanel.SetActive(false);
                RedeemSuccededPanel.SetActive(true);
                Inventory.RemovePerkFromInventory(PerkHolder);
                CallPerkRemovedFromDisplayEvent();
            }
            else
            {
                Debug.LogError("No Redeem Success Panel Attached");
            }
        }   
        else
        {
            if (RedeemFailedPanel != null)
                RedeemFailedPanel.SetActive(true);
            else Debug.LogError("No Redeem Failed Panel Attached");
        }
    }

}