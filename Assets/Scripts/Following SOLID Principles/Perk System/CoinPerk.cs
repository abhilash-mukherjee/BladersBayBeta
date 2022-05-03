using UnityEngine;
public class CoinPerk : IPerk
{

    public delegate void CoinAddHandler(int _Count);
    public static event CoinAddHandler OnCoinsAdded;
    private int m_coinsToAdd;
    private bool m_isRedeemed;
    private PerkType m_perkType;
    public CoinPerk(int coinsToAdd, PerkType perkType)
    {
        m_coinsToAdd = coinsToAdd;
        m_isRedeemed = false;
        m_perkType = perkType;
    }
    public void Redeem()
    {
        if (m_isRedeemed) return;
        OnCoinsAdded?.Invoke(m_coinsToAdd);
        Debug.Log($"{m_coinsToAdd} coins added");
        m_isRedeemed = true;
    }
    public int PerkCount { get => m_coinsToAdd;  }
    public PerkType PerkType()
    {
        return m_perkType;
    }
}
