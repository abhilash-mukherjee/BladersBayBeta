using System.Collections.Generic;
using UnityEngine;

public class GroupedDislayable : UIDisplayable
{
    [SerializeField]
    private List<UIDisplayable> displayables;
    public void PushDisplayable(UIDisplayable uIDisplayable)
    {
        displayables.Add(uIDisplayable);
    }
    public void PopDisplayable(UIDisplayable uIDisplayable)
    {
        if(displayables.Contains(uIDisplayable))
        displayables.Remove(uIDisplayable);
    }
    public override void EnterForward()
    {
        foreach (var d in displayables) d.EnterForward();
    }

    public override void EnterReverse()
    {
        foreach (var d in displayables) d.EnterReverse();
    }

    public override void ExitForward()
    {
        foreach (var d in displayables) d.ExitForward();
    }

    public override void ExitReverse()
    {
        foreach (var d in displayables) d.ExitReverse();
    }
}