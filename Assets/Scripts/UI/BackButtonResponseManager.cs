using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK;
using JMRSDK.InputModule;

public class BackButtonResponseManager : MonoBehaviour, IBackHandler
{
    [SerializeField]
    private GameEvent OnBackPressed;
    public delegate void BackButtonHandler();
    public static event BackButtonHandler OnBackButtonPressed;
    private void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
    public void OnBackAction()
    {
        OnBackButtonPressed?.Invoke();
        OnBackPressed.Raise();
    }

}
