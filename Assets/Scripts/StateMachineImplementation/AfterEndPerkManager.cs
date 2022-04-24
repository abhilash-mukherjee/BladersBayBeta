using System;
using System.Collections.Generic;
using UnityEngine;

public class AfterEndPerkManager : MonoBehaviour
{
    [SerializeField]
    private List<PerkHolder> InstantReedemableWinPerkHolders = new List<PerkHolder>();
    [SerializeField]
    private List<PerkHolder> InstantReedemableLossPerkHolders = new List<PerkHolder>();
    [SerializeField]
    private List<PerkHolder> AddToInventoryPerkHolders = new List<PerkHolder>();
    [SerializeField]
    private BeyBladeInventory inventory;
    [SerializeField]
    private GameObject player;
    

    private void OnEnable()
    {
        WinnerDecideManager.OnResultsDecided += OnWinnerDcided;
    }
    private void OnDisable()
    {
        WinnerDecideManager.OnResultsDecided -= OnWinnerDcided;

    }

    private void OnWinnerDcided(GameObject _winner, GameObject _looser)
    {
        if(player == _winner)
        {
            RedeemPerks(InstantReedemableWinPerkHolders);
            foreach (var _perk in AddToInventoryPerkHolders)
                inventory.AddPerkToInventory(_perk);
        }
        else RedeemPerks(InstantReedemableLossPerkHolders);
    }

    void RedeemPerks(List<PerkHolder> _holderList)
    {
        foreach (var _holder in _holderList)
        {
            _holder.RedeemAllPerks();
        }
    }
}
