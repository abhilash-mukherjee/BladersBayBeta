using System.Collections;
using UnityEngine;

public class AIController: InputController1
{
    [SerializeField]
    private KeyCode attackTrigger, defenceTrigger, staminaTrigger, balanceTrigger;
    [SerializeField]
    private GameEvent attackTriggerEvent, defenceTriggerEvent, staminaTriggerEvent, balanceTriggerEvent;
    [SerializeField]
    private StateController enemyStateController, playerStateController;
    [SerializeField]
    private AIState startingAIState;
    [SerializeField]
    private AIActionName startingActionName;
    [SerializeField]
    private float actionChangFrequency = 1.5f;
    [SerializeField]
    private float AIStartTime = 2f;
    public Collider enemyCollider;
    public Collider stadiumBoundary;
    public Vector3 stadiumCentrePosition;
    private AIState m_CurrentState;
    private  float m_currentActionTime = 1;
    private AIActionName m_currentActionName;
    private float m_timeSinceLastActionChange = 0f;
    public float CurrentActionTime { get => m_currentActionTime; set => m_currentActionTime = value; }
    public AIActionName CurrentActionName { get => m_currentActionName; set => m_currentActionName = value; }
    public float TimeSinceLastActionChange { get => m_timeSinceLastActionChange; set => m_timeSinceLastActionChange = value; }
    public float ActionChangFrequency { get => actionChangFrequency;  }
    private bool m_shouldRunAI = false;

    private void Awake()
    {
        m_CurrentState = startingAIState;
        m_currentActionName = startingActionName;
        StartCoroutine(EnableAI());
    }
    IEnumerator EnableAI()
    {
        yield return new WaitForSeconds(AIStartTime);
        m_shouldRunAI = true;
    }
    private void Update()
    {
        if (!m_shouldRunAI)
            return;
        m_CurrentState.UpdateState(enemyStateController, playerStateController,this);
        if(m_CurrentState.CurrentActionName != m_currentActionName)
        {
            m_currentActionName = m_CurrentState.CurrentActionName;
            m_currentActionTime = 1f;
            m_timeSinceLastActionChange = 0f;
        }
        m_timeSinceLastActionChange += Time.deltaTime;
    }
    public void ChangeMoveDir(Vector3 _newDir)
    {
        m_moveDirection = _newDir;
    }

    

}