using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDictionaryHolder : MonoBehaviour
{
    [SerializeField]
    private List<BeyBladeStateName> keys = new List<BeyBladeStateName>();
    [SerializeField]
    private List<State> values = new List<State>();

    private Dictionary<BeyBladeStateName, State> myDictionary = new Dictionary<BeyBladeStateName, State>();

    public Dictionary<BeyBladeStateName, State> StateDictionary { get => myDictionary;}

    public void CustomAwake()
    {
        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
        {
            myDictionary.Add(keys[i], values[i]);
        }
        List<BeyBladeStateName> lockedStates = new List<BeyBladeStateName>();
        foreach (var _element in myDictionary)
            if (_element.Value.Data.IsLocked)
                lockedStates.Add(_element.Key);
        foreach (var _lockedState in lockedStates)
            myDictionary.Remove(_lockedState);

        Debug.Log("Starting Dict Holder" +  myDictionary.Keys.Count);
    }

}