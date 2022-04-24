using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Keyboard Input System", menuName = "Input Systems/ Keyboard")]
public class KeyboardInputSystem : InputSystem
{
    [SerializeField]
    KeyCode moveLeft, moveRight, moveForward, moveBack;
    [SerializeField]
    private List<KeyTriggerMapping> triggerMappings;
    private float xInp, zInp;

    public override void CheckForAbilitySwitchTriggers(InputManager inputManager, GameObject enemyObject)
    {
        foreach (var tM in triggerMappings)
        {
            if (Input.GetKeyDown(tM.keyCode))
            {
                RaiseActionTriggerEvent(inputManager.gameObject, tM.actionToTrigger);
                Debug.Log(tM.actionToTrigger.name + " was raised");
            }
        }
    }

    public override void ScriptableStart(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }

    public override Vector3 UpdateInput(InputManager inputManager)
    {
        xInp = SetInputValue(moveRight, moveLeft);
        zInp = SetInputValue(moveForward, moveBack);
        return new Vector3(xInp, 0f, zInp);
    }

    private float SetInputValue(KeyCode positiveInput, KeyCode negetiveInput)
    {
        if (Input.GetKey(positiveInput)) return 1f;
        else if (Input.GetKey(negetiveInput)) return -1;
        else return 0f;
    }

}


