using UnityEngine;

[CreateAssetMenu(fileName ="New Player Data", menuName = "Data / Player Data")]
public class PlayerData : BeyBladeData
{
    public IntVariable CoinsEarned;
    [SerializeField]
    private IntVariable m_maximumLevelUnlocked;
    [SerializeField]
    private int HighestLevel;

    public IntVariable MaximumLevelUnlocked 
    { 
        get => m_maximumLevelUnlocked; 
        set 
        {
            if (value.Value >= HighestLevel)
                m_maximumLevelUnlocked.Value = HighestLevel;
            else if (value.Value < 1)
                m_maximumLevelUnlocked.Value = 1;
            else
                m_maximumLevelUnlocked.Value = value.Value;
        }
    }

    public BoolVariable DidLastBattleUnlockNewLevel;
}
 