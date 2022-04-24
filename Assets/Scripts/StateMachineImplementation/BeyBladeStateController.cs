using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeyBladeStateController : MonoBehaviour
{
    public delegate void ModeChangeHandler(BeyBladeStateName _currentModeName, GameObject _gameObject);
    public static event ModeChangeHandler OnBeyBladeStateChanged;
    [SerializeField]
    private StateBehaviour startingState;
    [SerializeField]
    private StateData beyBladeValues;
    [SerializeField]
    private List<StateEffectContainer> modeEffects = new List<StateEffectContainer>();
    [SerializeField]
    private BeyBladeStateAvailabilityEnum Available, UnAvailable, Activated;
    private BeyBladeStateName m_currentStateRequest;
    private StateBehaviour m_currentState;

    public BeyBladeStateName CurrentStateRequest { get => m_currentStateRequest; }
    public List<StateEffectContainer> ModeEffects { get => modeEffects; }
    public StateBehaviour CurrentState
    {
        get
        {
            return m_currentState;
        }
    }

   
    public GameObject StateControllerObject { get => this.gameObject; }

    private void Awake()
    {
        m_currentState = startingState;
        OnBeyBladeStateChanged?.Invoke(m_currentState.StateName, gameObject);
    }
    private void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        if (m_currentState != null)
            Gizmos.color = m_currentState.SceneGizmoColor;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
    public void ChangeCurrentStateRequest(BeyBladeStateName _newStateRequest)
    {
        m_currentStateRequest = _newStateRequest;
    }
}
[System.Serializable]
public class StateEffectContainer
{
    public GameObject effectPrefab;
    public BeyBladeStateName stateName;
}
