using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenFocusController : MonoBehaviour
{
    [SerializeField]
    private GameObject firstObjectOfFocus;
    private Stack<IHomeScreenFocusable> focusableStack = new Stack<IHomeScreenFocusable>();
    private void Start()
    {
        var _sF = firstObjectOfFocus.GetComponent<IHomeScreenFocusable>();
        if (_sF == null) 
        {
            Debug.LogError($"The gameobject : {firstObjectOfFocus} did not have an IHomeScreenFocusable type component on it");
            return;
        }
        focusableStack.Push(_sF);
    }

    public void ChangeFocusForward(GameObject _newFocusObject)
    {
        var _newFocus = _newFocusObject.GetComponent<IHomeScreenFocusable>();
        if (_newFocus == null)
        {
            Debug.LogError($"The gameobject : {_newFocusObject} did not have an IHomeScreenFocusable type component on it");
            return;
        }
        focusableStack.Peek().OnFocusRemoved();
        focusableStack.Push(_newFocus);
        Debug.Log("New Focus = " + _newFocus);
        focusableStack.Peek().OnFocusEntered();
    }

    public void ChangeFocusBackward()
    {
        if(focusableStack.Count > 1)
        {
            focusableStack.Peek().OnFocusRemoved();
            focusableStack.Pop();
            focusableStack.Peek().OnFocusEntered();
            Debug.Log("New Focus = " + focusableStack.Peek());

        }
        else
        {
            Debug.Log("Focus is on Base Level");
        }
    }
}

public interface IHomeScreenFocusable
{
    public void OnFocusEntered();
    public void OnFocusRemoved();
}
