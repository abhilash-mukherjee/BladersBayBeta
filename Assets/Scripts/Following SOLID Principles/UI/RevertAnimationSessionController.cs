using UnityEngine;

public class RevertAnimationSessionController : SessionController
{
    public override void Previous()
    {
        if (ForwardStack.Count == 0 && ReverseStack.Count == 0) return;
        if (ReverseStack.Count <= 0)
        {
            ForwardStack.Peek().ExitReverse();
            SessionRevertEvent.Raise();
            Debug.Log($"{gameObject} session reverted");
            return;
        }
        var displayedElement = ReverseStack.Pop();
        if (ForwardStack.Count <= 0)
        {
            ForwardStack.Push(Displayables[Displayables.Count - 1]);
            ForwardStack.Peek().ExitReverse();
            displayedElement.EnterReverse();
            return;
        }
        ForwardStack.Peek().ExitReverse();
        ForwardStack.Push(displayedElement);
        displayedElement.EnterReverse();
    }
}

