using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSiezer : MonoBehaviour
{
    [SerializeField]
    private Control[] controlsToSeize;
    public void SeizeControl()
    {
        for(int i = 0; i< controlsToSeize.Length; i++)
        {
            controlsToSeize[i].Value = 0f;
        }
    }
}
