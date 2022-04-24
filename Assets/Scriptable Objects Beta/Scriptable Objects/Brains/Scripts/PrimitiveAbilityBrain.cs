using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Primitive Ability Brain", menuName = "AI Brains / Ability Brain / Primitive")]
public class PrimitiveAbilityBrain : AbilityBrain
{
    [SerializeField]
    private InputTrigger[] inputTriggers;
    [SerializeField]
    private int triggersAvailable;
    public override List<InputTrigger> CheckTriggers(GameObject thisObject, GameObject enemyObject)
    {
        var _list = new List<InputTrigger>();

        _list.Add(inputTriggers[Random.Range(0, triggersAvailable)]);
        return _list;
    }
}
