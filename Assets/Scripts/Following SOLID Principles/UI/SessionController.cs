using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour, ISession
{
    [SerializeField]
    private List<UIDisplayable> displayables;
    [SerializeField]
    private GameEvent sessionRevertEvent, sessionEndEvent;
    private Stack<UIDisplayable> forwardStack, reverseStack;
    public void EndSession()
    {
        forwardStack.Clear();
        reverseStack.Clear();
        if(sessionEndEvent!= null) sessionEndEvent.Raise();
        Debug.Log("SessionEnded");
    }

    public void Next()
    {
        if (forwardStack.Count == 0 && reverseStack.Count == 0) return;
        if (forwardStack.Count <= 0)
        {
            EndSession();
            Debug.Log($"{gameObject.name} session ended");
            return;
        }
        var displayedElement = forwardStack.Pop();
        reverseStack.Push(displayedElement);
        displayedElement.ExitForward();
        if (forwardStack.Count <= 0)
        {
            EndSession();
            Debug.Log($"{gameObject.name} session ended");
            return;
        }
        forwardStack.Peek().EnterForward();
    }

    public void Previous()
    {
        if (forwardStack.Count == 0 && reverseStack.Count == 0) return;
        if (reverseStack.Count <= 0)
        {
            sessionRevertEvent.Raise();
            Debug.Log($"{gameObject} session reverted");
            return;
        }
        var displayedElement = reverseStack.Pop();
        if (forwardStack.Count <= 0)
        {
            forwardStack.Push(displayables[displayables.Count - 1]);
            forwardStack.Peek().ExitReverse();
            displayedElement.EnterReverse();
            return;
        }
        forwardStack.Peek().ExitReverse();
        forwardStack.Push(displayedElement);
        displayedElement.EnterReverse();
    }

    public void StartSession()
    {
        Debug.Log($"{gameObject.name} session started");
        forwardStack = new Stack<UIDisplayable>();
        reverseStack = new Stack<UIDisplayable>();
        for (int i = displayables.Count - 1; i > -1; i--)
        {
            forwardStack.Push(displayables[i]);
        }
        forwardStack.Peek().EnterForward();
    }
}

