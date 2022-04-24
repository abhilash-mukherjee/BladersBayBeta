using UnityEngine;
using System.Collections.Generic;

public abstract class AbilityBrain : ScriptableObject
{
    public abstract List<InputTrigger> CheckTriggers(GameObject gameObject, GameObject enemyObject);
}
