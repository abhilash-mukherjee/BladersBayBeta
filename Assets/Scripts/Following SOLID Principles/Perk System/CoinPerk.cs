using UnityEngine;
public class CoinPerk : IPerk
{

    public delegate void CoinAddHandler(int _Count, string _recieverID);
    public static event CoinAddHandler OnCoinsAdded;
    private int m_coinsToAdd;
    private string recieverID;
    private bool m_isRedeemed;
    private PerkType m_perkType;
    public CoinPerk(int coinsToAdd, PerkType perkType, string _recieverID)
    {
        m_coinsToAdd = coinsToAdd;
        m_isRedeemed = false;
        m_perkType = perkType;
        recieverID = _recieverID;
    }
    public void Redeem()
    {
        if (m_isRedeemed) return;
        OnCoinsAdded?.Invoke(m_coinsToAdd, recieverID);
        Debug.Log($"{m_coinsToAdd} coins added");
        m_coinsToAdd = 0;
        m_isRedeemed = true;
    }
    public int PerkCount { get => m_coinsToAdd;  }

    public string Reciever { get => recieverID; }

    public PerkType PerkType()
    {
        return m_perkType;
    }
}
