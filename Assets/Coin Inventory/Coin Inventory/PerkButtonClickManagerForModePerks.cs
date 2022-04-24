using UnityEngine;
public class PerkButtonClickManagerForModePerks : PerkButtonClickManager
{
    public delegate void ModeActivatedHandler();
    public static ModeActivatedHandler OnNewModeActivated;
    public override void RedeemButtonClicked()
    {
        if (PerkHolder.RedeemAllPerks())
        {
            if (RedeemSuccededPanel != null)
            {
                PerkPanel.SetActive(false);
                RedeemSuccededPanel.SetActive(true);
                OnNewModeActivated?.Invoke();
                Inventory.RemovePerkFromInventory(PerkHolder);
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

    public void RemovePerkFromDisplay()
    {
        CallPerkRemovedFromDisplayEvent();
    }
}
