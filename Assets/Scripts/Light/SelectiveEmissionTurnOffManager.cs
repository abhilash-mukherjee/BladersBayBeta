using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveEmissionTurnOffManager : MonoBehaviour
{
    [SerializeField]
    private Material material;

    [SerializeField]
    private BeyBladeStateName balanceStateName;
    [SerializeField]
    private List<StateController> stateControllers = new List<StateController>();
    private void Update()
    {
        foreach (var c in stateControllers)
        {
            if (c.CurrentState.Name != balanceStateName)
            {
                material.EnableKeyword("_EMISSION");
                break;
            }
            else material.DisableKeyword("_EMISSION");

        }
    }
}
