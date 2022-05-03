using System.Collections.Generic;
using UnityEngine;

public class GroupedDislayable : UIDisplayable
{
    [SerializeField]
    private List<UIDisplayable> displayables;
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