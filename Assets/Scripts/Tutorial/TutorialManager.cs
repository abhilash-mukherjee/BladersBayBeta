using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    public delegate void NextHandler();
    public delegate void BackHandler();
    public UnityEvent OnTutorialBeginingReached;
    public static event NextHandler OnNextClicked;
    public static event BackHandler OnBackClicked;
    [SerializeField]
    private List<CustomCommand> commandList;
    [SerializeField]
    private CanvasDisplayManager canvas;
    [SerializeField]
    private TutorialInputController tutorialInputController;
    private Stack<CustomCommand> forwardStack, reverseStack;
    private CustomCommand currentCommand;
    //This variable is to avoid two quick clicks on the next buttons. This gives rise to bugs
    private bool shouldAllowOk = true;
    private bool shouldAllowBack = true;
    public TutorialInputController TutorialInputController { get => tutorialInputController; }

    private int commandListCount = 0;
    public int CommandListCount { get => commandListCount; }

    private void Awake()
    {
        forwardStack = new Stack<CustomCommand>();
        reverseStack = new Stack<CustomCommand>();
    }
    private void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
        for (int i = commandList.Count-1; i>=0; i--)
        {
            if (HasDuplicateEntry(i))
                return;
            forwardStack.Push(commandList[i]);
        }
        commandListCount = commandList.Count;
        currentCommand = forwardStack.Pop();
    }
    private void OnEnable()
    {
        MovementMarkerManager.OnTargetReached += OnMarkerReached;
        BackButtonResponseManager.OnBackButtonPressed += Back;
    }
    private void OnDisable()
    {
        MovementMarkerManager.OnTargetReached -= OnMarkerReached;
        BackButtonResponseManager.OnBackButtonPressed -= Back;

    }
    //Next does not excute anything. It just pops the next command and puts it on standby
    //unless the trigger for the current command is executed, nothing happens
    //DO NOT assign this Next with UI buttons
    public void Next()
    {
        reverseStack.Push(currentCommand);
        if(forwardStack.Count ==0)
        {
            currentCommand = commandList[commandList.Count - 1];
            Debug.Log("Nothing more to execute");
            return;
        }
        Debug.Log("Next functon called");
        currentCommand = forwardStack.Pop();
        OnNextClicked?.Invoke();
    }
    //Back can be called from outside. you can assign UI buttons to this Back() method
    public void Back()
    {
        if (!shouldAllowBack) //check if OK is not double clicked
        {
            Debug.Log("OK is double clicked");
            return;
        }
        shouldAllowBack = false;
        Debug.Log("Back Button is Clicked");
        forwardStack.Push(currentCommand);
        if(reverseStack.Count ==0)
        {
            Debug.Log("No more previous step");
            OnTutorialBeginingReached?.Invoke();
            currentCommand = commandList[0];
            return;
        }
        currentCommand = reverseStack.Pop();
        currentCommand.Command.UnExecute();
        OnBackClicked?.Invoke();
        StartCoroutine(EnableBackClick());
    }

    public void OnSwipeLeft()
    {
        if (currentCommand.Trigger == TriggerType.LeftSwipe)
            currentCommand.Command.Execute();
    }

    public void OnSwipeRight()
    {
        if (currentCommand.Trigger == TriggerType.RightSwipe)
            currentCommand.Command.Execute();
    }

    public void OnSwipeUp()
    {
        if (currentCommand.Trigger == TriggerType.UpSwipe)
            currentCommand.Command.Execute();
    }

    public void OnFn1Action()
    {
        Debug.Log("FN1 pressed");
        if (currentCommand.Trigger == TriggerType.FN1Click)
            currentCommand.GetComponent<ICommand>().Execute(); 
        else
        {
            Debug.Log($"Trigger for current command: {currentCommand.Trigger}");
            Debug.Log("FN1 pressed but nothing happened");
        }
    }

    public void OnOkClicked()
    {
        if (!shouldAllowOk) //check if OK is not double clicked
        {
            Debug.Log("OK is double clicked");
            return;
        }
        shouldAllowOk = false;
        Debug.Log("Ok clicked");
        if (currentCommand.Trigger == TriggerType.OkClicked)
            currentCommand.GetComponent<ICommand>().Execute();
        StartCoroutine(EnableOKClick());
    }
    IEnumerator EnableOKClick()
    {
        yield return new WaitForSeconds(1f);
        shouldAllowOk = true;
    }
    IEnumerator EnableBackClick()
    {
        yield return new WaitForSeconds(1f);
        shouldAllowBack = true;
    }
    public void OnMarkerReached()
    {
        Debug.Log("Ok clicked");
        if (currentCommand.Trigger == TriggerType.MarkerReached)
            currentCommand.GetComponent<ICommand>().Execute();
    }

    public enum TriggerType
    {
        LeftSwipe, RightSwipe,UpSwipe,DownSwipe,FN1Click, MarkerReached, EnemyHit, OkClicked
    }
    private bool HasDuplicateEntry(int i)
    {
        if (commandList.FindAll(p => p == commandList[i]).Count > 1)
        {
            Debug.LogError("Duplicate value entered in Custom Command list");
            return true;
        }
        return false;
    }

}

