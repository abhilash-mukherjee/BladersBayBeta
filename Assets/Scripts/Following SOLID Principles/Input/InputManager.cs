using System;
using System.Collections;
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

    public GameObject Enemy { get => enemy; }
    public Transform StadiumCentre { get => stadiumCentre; }
    private void Start()
    {
        
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
    public void StartInput(float time)
    {
        StartCoroutine(StartAIAfterTime(time));
    }
    IEnumerator StartAIAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("AI Atarted");
        m_shouldTakeInput = true;
    }

}

[System.Serializable]
public class KeyTriggerMapping
{
    public KeyCode keyCode;
    public InputTrigger actionToTrigger;

}
