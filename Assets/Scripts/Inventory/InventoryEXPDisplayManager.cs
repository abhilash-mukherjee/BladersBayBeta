using UnityEngine;
using TMPro;

public class InventoryEXPDisplayManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI expCount;
    [SerializeField]
    private string inventoryID = "PLAYER_INVENTORY";
    private void OnEnable()
    {
        UpdateEXPCount();
    }

    public void UpdateEXPCount()
    {
        var i = GameDataManager.Instance.UnitOfWork.Inventories.GetByID(inventoryID);
        if (i == null) expCount.text = 0.ToString();
        else expCount.text = i.ExpCount.ToString();
    }

}
