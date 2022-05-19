using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK;
using JMRSDK.InputModule;

public class BackButtonResponseManager : MonoBehaviour, IBackHandler
{
    [SerializeField]
    private GameEvent OnBackPressed;
    private bool m_shouldEnableBackButtonResponse = true;
    public delegate void BackButtonHandler();
    public static event BackButtonHandler OnBackButtonPressed;
    private void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
    public void OnBackAction()
    {
        if (!m_shouldEnableBackButtonResponse) return;
        OnBackButtonPressed?.Invoke();
        OnBackPressed.Raise();
    }
    public void EnableBackButton()
    {
        m_shouldEnableBackButtonResponse = true;
    }
    public void DisableBackButton()
    {

        m_shouldEnableBackButtonResponse = false;
    }
}
