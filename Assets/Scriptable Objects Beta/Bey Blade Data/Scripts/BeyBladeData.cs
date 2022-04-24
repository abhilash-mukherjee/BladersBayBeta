using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New BeyBlade Data", menuName = "Data / Bey Blade Data")]
public class BeyBladeData : ScriptableObject
{
    public StateData AttackData, DefenceData, StaminaData, BalanceData;
    public string ModelName;
    public GameObject Model;
    public Sprite icon;
}
 