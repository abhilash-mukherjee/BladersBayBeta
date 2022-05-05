using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Attack Brain", menuName = "AI Brains / Ability Brain / Single Ability")]
public class SingleAbilityBrain : AbilityBrain
{
    [SerializeField]
    private InputTrigger abilityTigger;
    public override List<InputTrigger> CheckTriggers(GameObject thisObject, GameObject enemyObject)
    {
        var _list = new List<InputTrigger>
        {
            abilityTigger
        };
        return _list;
    }
}
