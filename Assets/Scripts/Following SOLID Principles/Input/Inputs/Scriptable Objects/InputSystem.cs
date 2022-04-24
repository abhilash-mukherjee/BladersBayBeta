using JMRSDK.InputModule;
using UnityEngine;

public abstract class InputSystem : ScriptableObject
{
    public delegate void TriggerActivationHandler(GameObject obj, InputTrigger trigger);
    public static event TriggerActivationHandler OnActionTriggered;
    public  abstract Vector3 UpdateInput(InputManager inputManager);
    public abstract void CheckForAbilitySwitchTriggers(InputManager inputManager, GameObject enemyObject);
    protected void RaiseActionTriggerEvent(GameObject obj, InputTrigger inputTrigger)
    {
        Debug.Log($"{inputTrigger} raised of {obj}");
        OnActionTriggered?.Invoke(obj, inputTrigger);
    }
    public abstract void ScriptableStart(GameObject gameObject);
}
