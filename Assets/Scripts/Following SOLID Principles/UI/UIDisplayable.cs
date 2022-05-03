using UnityEngine;

public abstract class UIDisplayable : MonoBehaviour, IUIDisplayable
{
    public abstract void EnterForward();

    public abstract void EnterReverse();
    public abstract void ExitForward();

    public abstract void ExitReverse();
}
