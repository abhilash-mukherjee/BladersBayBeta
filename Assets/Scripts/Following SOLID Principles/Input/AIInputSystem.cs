using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New AI Input System", menuName = "Input Systems/ AI")]
public class AIInputSystem : InputSystem
{
    [SerializeField]
    int TickPeriodForMovementChange = 20;
    [SerializeField]
    int TickPeriodForAbilityChange = 20;
    [SerializeField]
    private MovementBrain movementBrain;
    [SerializeField]
    private AbilityBrain abilityBrain;
    private Vector3 m_currentInput = Vector3.zero;
    int m_movementFramesTicked = 0;
    int m_abilityFramesTicked = 0;

    public override void CheckForAbilitySwitchTriggers(InputManager inputManager, GameObject enemyObject)
    {
        m_abilityFramesTicked++;
        if (m_abilityFramesTicked % TickPeriodForAbilityChange != 0) return;
        var listOfTriggers = abilityBrain.CheckTriggers(inputManager.gameObject, enemyObject);
        if (listOfTriggers == null) return;
        foreach(var trigger in listOfTriggers)
        RaiseActionTriggerEvent(inputManager.gameObject,trigger);
    }

    public override Vector3 UpdateInput(InputManager inputManager)
    {
        m_movementFramesTicked++;
        if (m_movementFramesTicked % TickPeriodForMovementChange != 0) return m_currentInput;
        m_currentInput = movementBrain.GetMoveDir(inputManager.gameObject, inputManager.Enemy, inputManager.StadiumCentre,m_currentInput);
        return m_currentInput;
    }
    public override void ScriptableStart(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }
}


