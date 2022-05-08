using System.Collections.Generic;
using UnityEngine;

public class ComponentTurnOffManager : MonoBehaviour
{
    [SerializeField]
    private List<MonoBehaviour> scriptsToDisable = new List<MonoBehaviour>();
    [SerializeField]
    private List<Collider> collidersToDisable = new List<Collider>();

    public void TurnOffComponents()
    {
        foreach (var _script in scriptsToDisable)
            _script.enabled = false;
        foreach (var _collider in collidersToDisable)
            _collider.enabled = false;
        Debug.Log("Components turned off");
    }
}
