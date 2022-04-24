using UnityEngine;

public class KeyBoardInputController1 : InputController1
{
    [SerializeField]
    private KeyCode attackTrigger, defenceTrigger, staminaTrigger, balanceTrigger;
    [SerializeField]
    private GameEvent attackTriggerEvent, defenceTriggerEvent, staminaTriggerEvent, balanceTriggerEvent;
    private void Update()
    {
        float x,z;
        if (Input.GetKey(KeyCode.LeftArrow))
            x = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            x = 1f;
        else
            x = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
            z = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            z = -1f;
        else
        {
            z = 0;
        }
        Vector3 _tempMove = new Vector3(x, 0f, z);
        _tempMove.Normalize();
        m_moveDirection = _tempMove;

        if(Input.GetKeyDown(attackTrigger))
        {
            attackTriggerEvent.Raise();
        }
        else if(Input.GetKeyDown(defenceTrigger))
        {
            defenceTriggerEvent.Raise();
        }
        else if(Input.GetKeyDown(staminaTrigger))
        {
            staminaTriggerEvent.Raise();
        }
        else if(Input.GetKeyDown(balanceTrigger))
        {
            balanceTriggerEvent.Raise();
        }
    }
}