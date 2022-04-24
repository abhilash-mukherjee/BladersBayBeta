using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CustomCommand : MonoBehaviour
{
    public static List<CustomCommand> customCommandsInCurrentScene = new List<CustomCommand>();
    [SerializeField]
    protected List<CustomCommand> priorCommandsToExecute;
    protected bool hasExecuted = false;
    [SerializeField]
    protected TutorialManager.TriggerType trigger;
    [SerializeField]
    protected UnityEvent OnStepExecuted, OnStepUnExecuted;
    protected ICommand command;

    public TutorialManager.TriggerType Trigger { get => trigger; }
    public bool HasExecuted { get => hasExecuted; }
    public ICommand Command { get => command;}
    
    protected void AddThisInstanceToCustomCommandList()
    {
        if (customCommandsInCurrentScene.Find(p => p == this))
            return;
        customCommandsInCurrentScene.Add(this);
    }
    protected void RemoveThisInstanceFromCustomCommandList()
    {
        if (customCommandsInCurrentScene.Find(p => p == this))
            customCommandsInCurrentScene.Remove(this);
    }
}
