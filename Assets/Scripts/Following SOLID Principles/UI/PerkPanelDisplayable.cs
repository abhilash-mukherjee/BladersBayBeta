using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkPanelDisplayable : PanelDisplayable
{
    public delegate void CachedPerkHandler(List<IPerk> cachedPerks, PerkPanelDisplayable cachingObject);
    public static event CachedPerkHandler OnPerksCached;
    [SerializeField]
    private PerkPool.PerkMessege perkMessege;
    private bool m_perksRedeemed = false;
    private List<IPerk> cachedPerks;
    private void OnEnable()
    {
        PerkPool.OnPerksGenerated += CachePerks;
    }
    private void OnDisable()
    {
        
        PerkPool.OnPerksGenerated -= CachePerks;
    }

    private void CachePerks(List<IPerk> _generatedPerks, PerkPool.PerkMessege _perkMessege)
    {
        if (_perkMessege != perkMessege) return;
        cachedPerks = _generatedPerks;
        Debug.Log("perks cached ");
        OnPerksCached?.Invoke(cachedPerks, this);
         
    }

    private void RedeemCachedPerks()
    {
        if (cachedPerks != null)
        {
            foreach (var _perk in cachedPerks)
            {
                _perk.Redeem();
            }
            Debug.Log("caced perks redeemed");
        }
        else Debug.Log("caced perks = null");
        m_perksRedeemed = true;
    }

    public override void EnterForward()
    {
        base.EnterForward();
        if(!m_perksRedeemed)
        {

        }
    }
    public override void ExitForward()
    {
        Debug.Log("Inside Exit Forward of Perk Panel");
        base.ExitForward();
        if(!m_perksRedeemed)
        {
            RedeemCachedPerks();

        }

    }


    public override void EnterReverse()
    {
        base.EnterReverse();
    }

    public override void ExitReverse()
    {
        base.ExitReverse();
    }
}
