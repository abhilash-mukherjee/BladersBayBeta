using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterGamePerkGiver : PerkPool
{
    [SerializeField]
    private int coinsWhenWin, coinsWhenLost;
    [SerializeField]
    private PerkType coinPerkType, experiencePerkType;
    [SerializeField]
    private FloatVariable EnemyHP;
    [SerializeField]
    private float ExpMultiplier = 0.5f;
    [SerializeField]
    private string perkRecieverID = "Player_Main";
    private int m_coinsToAdd = 0;
    private PerkPool.PerkMessege m_resultMessege;
    public override void GeneratePerks()
    {
        var perksGenerated = new List<IPerk>();
        perksGenerated.Add(GenerateCoinPerk());
        perksGenerated.Add(GenerateExperiencePerk());
        RaisePerksGeneratedEvent(perksGenerated, m_resultMessege);
    }

    private CoinPerk GenerateCoinPerk()
    {
        return new CoinPerk(m_coinsToAdd, coinPerkType, perkRecieverID);
        
    }
    
    private ExperiencePerk GenerateExperiencePerk()
    {
        float _expToAdd = ExpMultiplier * (100 - EnemyHP.Value);
        return new ExperiencePerk((int)_expToAdd, experiencePerkType, perkRecieverID);
        
    }

    public void GenerateWinningPerks()
    {
        m_coinsToAdd = coinsWhenWin;
        m_resultMessege = PerkPool.PerkMessege.WINNING_PERK;
        GeneratePerks();    
    }
    public void GenerateLoosingPerks()
    {
        m_coinsToAdd = coinsWhenLost;
        m_resultMessege = PerkPool.PerkMessege.LOOSING_PERK;
        GeneratePerks();
    }

}
