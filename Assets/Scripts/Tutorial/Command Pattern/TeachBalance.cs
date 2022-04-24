using UnityEngine;

public class TeachBalance : CustomCommand, ICommand
{
    private void Awake()
    {
        AddThisInstanceToCustomCommandList();
    }
    private void OnDisable()
    {
        RemoveThisInstanceFromCustomCommandList();
    }
    private void Start()
    {
        command = this;
    }
    public void Execute()
    {
        foreach(var _Command in priorCommandsToExecute)
        {
            if (_Command.HasExecuted == false)
                return;
        }
        Debug.Log("Teach Balance Done");
        hasExecuted = true;
        OnStepExecuted?.Invoke();
    }

    public void UnExecute()
    {
        hasExecuted = false;
        Debug.Log($"Unexecuted TeachBalance");
        OnStepUnExecuted?.Invoke();
    }
}