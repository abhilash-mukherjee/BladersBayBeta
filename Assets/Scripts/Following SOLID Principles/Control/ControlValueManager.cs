using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlValueManager : MonoBehaviour
{
    [SerializeField]
    private Control[] controlsToSeize;
    public void SeizeControl()
    {
        for(int i = 0; i< controlsToSeize.Length; i++)
        {
            controlsToSeize[i].Value = 0f;
        }
        Debug.Log("All controls seized");
    }

    public void GiveFullControll(Control _controlToMaximize)
    {
        _controlToMaximize.Value = 1;
        Debug.Log($"{_controlToMaximize} controls maximized");
    }
    public void TakeAwayControl(Control _controlToMinimize)
    {
        Debug.Log($"{_controlToMinimize} controls seized");
        _controlToMinimize.Value = 0;
    }
    public void AlterControl(Control _controlToAlter, float _newValue)
    {
        _controlToAlter.Value = _newValue;
    }
}
