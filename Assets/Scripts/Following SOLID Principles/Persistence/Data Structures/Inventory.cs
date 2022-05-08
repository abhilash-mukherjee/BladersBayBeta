using System;
using UnityEngine;

[Serializable]
public class Inventory : Base
{
    public delegate void InventoryDataChangeHandler(string _id);
    public static event InventoryDataChangeHandler OnInventoryDataChanged;
    [SerializeField] private int coinCount;
    [SerializeField] private int expCount;

    public int CoinCount
    {
        get => coinCount;
        set
        {
            coinCount = value;
            OnInventoryDataChanged?.Invoke(ID);
        }
    }
    public int ExpCount
    {
        get => expCount;
        set
        {
            expCount = value;
            OnInventoryDataChanged?.Invoke(ID);
        }
    }

    public Inventory(int _coinCount, int _expCount)
    {
        coinCount = _coinCount;
        expCount = _expCount;
    }
}