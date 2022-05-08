using UnityEngine;

public class InputActionListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent inputActionRecievedEvent;
    [SerializeField]
    private InputTrigger trigger;
    private void OnEnable()
    {
        InputSystem.OnActionTriggered += OnInputActionRecieved;
    }
    private void OnDisable()
    {
        
        InputSystem.OnActionTriggered -= OnInputActionRecieved;
    }

    private void OnInputActionRecieved(GameObject _obj, InputTrigger _trigger)
    {
        if (_trigger == trigger) inputActionRecievedEvent.Raise();
    }

}