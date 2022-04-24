using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PerkButtonClickManager : MonoBehaviour, IPerkButtonClickManager
{
    public delegate void ButtonClickHandler(GameObject _GameObject);
    public delegate void InventoryUpdateHandler();
    public delegate void PerkRemoveHandler(GameObject _perkObject);
    public static event ButtonClickHandler OnPerkButtonClicked;
    public static event PerkRemoveHandler OnPerkRemovedFromInventory;
    [SerializeField]
    private GameObject redeemSuccededPanel, redeemFailedPanel, perkPanel;
    [SerializeField]
    private PerkHolder perkHolder;
    [SerializeField]
    private BeyBladeInventory inventory;
    protected PerkHolder PerkHolder { get => perkHolder; }
    protected GameObject RedeemSuccededPanel { get => redeemSuccededPanel; }
    protected GameObject RedeemFailedPanel { get => redeemFailedPanel;  }
    protected GameObject PerkPanel { get => perkPanel;  }
    public BeyBladeInventory Inventory { get => inventory; }

    public virtual void RedeemButtonClicked()
    {
       
    }
    protected void CallPerkRemovedFromDisplayEvent()
    {
        OnPerkRemovedFromInventory?.Invoke(gameObject);
    }
}
