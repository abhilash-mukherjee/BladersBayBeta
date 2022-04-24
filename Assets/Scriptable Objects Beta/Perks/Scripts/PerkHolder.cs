using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class PerkHolder : ScriptableObject, IPerkHolder
{
    public GameObject perkPrefab;
    [SerializeField]
    private int coinsRequiredToUnlock;
    [SerializeField]
    private IntVariable playerCoinCount;

    protected IntVariable PlayerCoinCount { get => playerCoinCount;  }
    protected int CoinsRequiredToUnlock { get => coinsRequiredToUnlock;}

    public virtual bool RedeemAllPerks()
    {
        return false;
    }
}
