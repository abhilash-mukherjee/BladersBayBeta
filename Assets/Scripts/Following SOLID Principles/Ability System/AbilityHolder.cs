using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField]
    private Ability ability;
    [SerializeField]
    private BaseData abilityData;
    [SerializeField]
    private InputTrigger trigger;
    private void OnEnable()
    {
        InputSystem.OnActionTriggered += CheckTrigger;
    }
    private void OnDisable()
    {
        InputSystem.OnActionTriggered -= CheckTrigger;   
    }
    private void Update()
    {
        ability.UpdateAbility(gameObject, abilityData);
    }
    private void CheckTrigger(GameObject obj, InputTrigger inputTrigger)
    {
        if (obj != gameObject) return;
        if (inputTrigger == trigger && abilityData.IsReady && !abilityData.IsAbilityLocked) ability.ActivateAbility(gameObject, abilityData);

    }
}
