using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenFocusableObject : MonoBehaviour, IHomeScreenFocusable
{
    [SerializeField]
    private List<HomeScreenElement> elementsToActivateWhenFocused = new List<HomeScreenElement>();
    [SerializeField]
    private List<HomeScreenElement> elementsToDeActivateWhenFocused = new List<HomeScreenElement>();
    public void OnFocusEntered()
    {
        foreach (var _obj in elementsToActivateWhenFocused)
            _obj.Activate();
        foreach (var _obj in elementsToDeActivateWhenFocused)
            _obj.DeActivate();
    }

    public void OnFocusRemoved()
    {
        foreach (var _obj in elementsToActivateWhenFocused)
            _obj.DeActivate();
        foreach (var _obj in elementsToDeActivateWhenFocused)
            _obj.Activate();
    }
}
