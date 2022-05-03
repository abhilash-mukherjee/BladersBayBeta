using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New BeyBlade Data", menuName = "Data / Bey Blade Data")]
public class BeyBladeData : ScriptableObject
{
    public AbilityData AttackData, DefenceData, StaminaData, BalanceData;
    public string ModelName, PlayerName;
    public GameObject Model;
    public Sprite icon;
    public Sprite characterImage;
}
 