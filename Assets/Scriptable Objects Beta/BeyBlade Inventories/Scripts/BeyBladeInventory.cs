using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeyBlade Inventory", menuName = "Inventory")]
public class BeyBladeInventory : ScriptableObject
{
    [SerializeField]
    private IntVariable PlayerCoinCount;
    private List<PerkHolder> inventoryPerkList = new List<PerkHolder>();

    public List<PerkHolder> InventoryPerkList { get => inventoryPerkList; }

    private void OnEnable()
    {
        inventoryPerkList.Clear();
    }
    private void OnDisable()
    {
        inventoryPerkList.Clear();
    }
    public void AddPerkToInventory(PerkHolder _perk)
    {
        if (inventoryPerkList.Contains(_perk))
            return;
        else
        {
            if (_perk.perkPrefab != null)
            {
                if(_perk.perkPrefab.GetComponent<DiaplayablePerk>() == null )
                    _perk.perkPrefab.AddComponent<DiaplayablePerk>();
            }
            inventoryPerkList.Add(_perk);
        }
    }
    public void RemovePerkFromInventory(PerkHolder _perkHolder)
    {
        if (!inventoryPerkList.Contains(_perkHolder))
            return;
        inventoryPerkList.Remove(_perkHolder);
    }
}


