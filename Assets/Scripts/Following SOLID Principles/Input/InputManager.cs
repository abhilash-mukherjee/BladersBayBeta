using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using JMRSDK.InputModule;
using JMRSDK;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    [SerializeField]
    private InputVector InputVector;
    [SerializeField]
    private InputSystem input;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform stadiumCentre;
    private bool m_shouldTakeInput = false;
    private List<InputManager> inputManagers;
    public GameObject Enemy { get => enemy; }
    public Transform StadiumCentre { get => stadiumCentre; }
    private void Awake()
    {
        inputManagers = GetComponents<InputManager>().ToList();
    }
    private void Update()
    {
        if (!m_shouldTakeInput)
        {
            return;
        }
        var inp = input.UpdateInput(this);
        InputVector.SetValue(inp.x,inp.y,inp.z) ;
        input.CheckForAbilitySwitchTriggers(this, enemy);
    }
    public void StartAllInput(float _time)
    {
        foreach (var im in inputManagers) im.StartInput(_time);
    }
    public void StartInput(float time)
    {
        StartCoroutine(StartAIAfterTime(time));
    }
    IEnumerator StartAIAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("AI Started");
        m_shouldTakeInput = true;
    }

}

[System.Serializable]
public class KeyTriggerMapping
{
    public KeyCode keyCode;
    public InputTrigger actionToTrigger;

}
