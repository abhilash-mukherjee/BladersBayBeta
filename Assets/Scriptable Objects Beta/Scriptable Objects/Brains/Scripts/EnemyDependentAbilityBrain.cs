using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Enemy Dependent Ability Brain", menuName = "AI Brains / Ability Brain / Enemy Dependent")]
public class EnemyDependentAbilityBrain : AbilityBrain
{
    [SerializeField]
    private List<NextModeSwitchProbability> modeSwitchProbabilityList;
    public override List<InputTrigger> CheckTriggers(GameObject thisObject, GameObject enemyObject)
    {

        var _list = new List<InputTrigger>();
        if (enemyObject.TryGetComponent(out StatManager statManager))
        {
            var enemyModeName = statManager.CurrentStats.AbilityName;
            var _newTrigger = ChooseNewAbility(enemyModeName);
            _list.Add(_newTrigger);

        }
        else
        {
            Debug.LogError("The enemy did not contain a statManager");
        }
        return _list;
    }

    private InputTrigger ChooseNewAbility(AbilityName enemyModeName)
    {
        var probabilityList = modeSwitchProbabilityList.Find(p => p.enemyAbility = enemyModeName).AbilitySwitchProbabilities;
        int[] weights = new int[probabilityList.Count];
        for(int i = 0; i < probabilityList.Count; i++)
        {
            weights[i] = probabilityList[i].probability;
        }
        var index = GetRandomWeightedIndex(weights);

        return probabilityList[index].abilityTrigger;
    }

    public int GetRandomWeightedIndex(int[] weights)
    {
        // Get the total sum of all the weights.
        int weightSum = 0;
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
        }

        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = weights.Length - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, weightSum) < weights[index])
            {
                return index;
            }

            // Remove the last item from the sum of total untested weights and try again.
            weightSum -= weights[index++];
        }

        // No other item was selected, so return very last index.
        return index;
    }

}

[System.Serializable]
public class NextModeSwitchProbability
{
    public AbilityName enemyAbility;
    public List<AbilityToProbabilityMapping> AbilitySwitchProbabilities;
}
[System.Serializable]
public class AbilityToProbabilityMapping
{
    public AbilityName abilityName;
    public InputTrigger abilityTrigger;
    [Range(0,100)]
    public int probability;
}