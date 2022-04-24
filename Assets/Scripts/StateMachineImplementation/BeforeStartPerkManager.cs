using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeStartPerkManager : MonoBehaviour
{
    [SerializeField]
    private List<PerkHolder> PerkHolders = new List<PerkHolder>();
    private void Awake()
    {
        foreach(var _holder in PerkHolders)
        {
            _holder.RedeemAllPerks();
        }
    }
}
