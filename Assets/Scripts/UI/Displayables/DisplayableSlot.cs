using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DisplayableSlot: MonoBehaviour
{
    [SerializeField]
    private List<Displayable> displayables = new List<Displayable>();
    public void AppearForward()
    {
        foreach(var _displayable in displayables)
        {
            _displayable.GetComponent<IDisplayable>().AppearForward();
        }
    }
    public void AppearReverse()
    {
        foreach(var _displayable in displayables)
        {
            _displayable.GetComponent<IDisplayable>().AppearReverse();
        }
    }

    public void DisappearForward()
    {
        foreach (var _displayable in displayables)
        {
            _displayable.GetComponent<IDisplayable>().DisappearForward();
        }
    }
    public void DisappearReverse()
    {
        foreach (var _displayable in displayables)
        {
            _displayable.GetComponent<IDisplayable>().DisappearReverse();
        }
    }
}