using UnityEngine;
using TMPro;
using System;

public class InventoryCoinDisplayManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinCount;
    [SerializeField]
    private string inventoryID = "PLAYER_INVENTORY";
    private void OnEnable()
    {
        UpdateCoinCount();
    }

    public void UpdateCoinCount()
    {
        var i = GameDataManager.Instance.UnitOfWork.Inventories.GetByID(inventoryID);
        if (i == null) coinCount.text = 0.ToString();
        else coinCount.text = i.CoinCount.ToString();
    }

}
