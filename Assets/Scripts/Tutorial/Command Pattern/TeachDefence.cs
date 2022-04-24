using UnityEngine;

public class TeachDefence : CustomCommand, ICommand
{
    public ICommand iCommand;
    private void Awake()
    {
        AddThisInstanceToCustomCommandList();
    }
    private void Start()
    {
        command = this;

    }
    private void OnDisable()
    {
        RemoveThisInstanceFromCustomCommandList();
    }
    public void Execute()
    {
        foreach(var _Command in priorCommandsToExecute)
        {
            if (_Command.HasExecuted == false)
                return;
        }
        Debug.Log("Teach Defence Done");
        hasExecuted = true;
        OnStepExecuted?.Invoke();
    }

    public void UnExecute()
    {
        hasExecuted = false;
        Debug.Log($"Unexecuted TeachDefence");
        OnStepUnExecuted?.Invoke();
    }
}
