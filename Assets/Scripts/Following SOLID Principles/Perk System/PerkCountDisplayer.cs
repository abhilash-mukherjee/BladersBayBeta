using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerkCountDisplayer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI perkCount;
    [SerializeField]
    private PerkType perkType;
    [SerializeField]
    private PerkPanelDisplayable cachingObject;
    private int m_count;
    private void OnEnable()
    {
        PerkPanelDisplayable.OnPerksCached += CheckIfMatchingPerkGenerated;
    }
    private void OnDisable()
    {
        PerkPanelDisplayable.OnPerksCached -= CheckIfMatchingPerkGenerated;
        
    }

    private void CheckIfMatchingPerkGenerated(List<IPerk> cachedPerks, PerkPanelDisplayable cachingObject)
    {
        if (cachingObject != this.cachingObject) return;
        var perk = cachedPerks.Find(p => p.PerkType() == perkType);
        if (perk == null)
        {
            Debug.LogError("No matching Perk Type found");
            return;
        }
        m_count = perk.PerkCount;
        UpdateCount();
    }

    public void UpdateCount()
    {
        perkCount.text = m_count.ToString();
    }
}
