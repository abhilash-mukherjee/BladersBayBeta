using System;
using System.Threading.Tasks;
using UnityEngine;

public class InventoryDataManager: MonoBehaviour
{
    [SerializeField]
    private string inventoryID = "PLAYER_INVENTORY";
    [SerializeField]
    private string playerID = "Main_Player";
    [SerializeField]
    private UnitOfWork unitOfWork;
    private void OnEnable()
    {
        CoinPerk.OnCoinsAdded += CoinPerk_OnCoinsAdded;
        ExperiencePerk.OnExperienceAdded += ExpPerk_OnExpAdded;
    }
    private void OnDisable()
    {
        CoinPerk.OnCoinsAdded -= CoinPerk_OnCoinsAdded;
        ExperiencePerk.OnExperienceAdded -= ExpPerk_OnExpAdded;
    }

    private void CoinPerk_OnCoinsAdded(int _Count, string _recieverID)
    {
        if (_recieverID != playerID) return;
        var _inventory = unitOfWork.Inventories.GetByID(inventoryID);
        _inventory.CoinCount += _Count;
    }
    private void ExpPerk_OnExpAdded(int _Count, string _recieverID)
    {
        if (_recieverID != playerID) return;
        var _inventory = unitOfWork.Inventories.GetByID(inventoryID);
        _inventory.ExpCount += _Count;
        unitOfWork.Save();
    }

    public void OnDataLoaded()
    {
        var _inventory = unitOfWork.Inventories.GetByID(inventoryID);
        if (_inventory == null)
        {
            var _newInv = new Inventory(0, 0);
            _newInv.ID = inventoryID;
            unitOfWork.Inventories.Add( _newInv);
        }
    }
}