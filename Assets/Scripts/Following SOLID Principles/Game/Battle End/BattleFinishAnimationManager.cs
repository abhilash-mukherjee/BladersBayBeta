using System;
using System.Collections;
using UnityEngine;

public class BattleFinishAnimationManager: MonoBehaviour
{
    public delegate void AnimationFinishHandler(GameObject _winner, GameObject _looser);
    public static event AnimationFinishHandler OnBeyBladesRisedAboveGround;
    [SerializeField]
    private Transform centreTransform;
    [SerializeField]
    private float time = 4f;
    [SerializeField]
    private float waitTime = 4f;
    [SerializeField]
    private Collider winnerTarget, looserTarget;
    [SerializeField]
    private GameObject player, enemy;
    private BeyBladeAfterBattle m_winner, m_losser;
    private bool m_animationStarted = false, m_animationFinished = false, m_FinishEventRaised = false;
    int targetReachStatus = 0;
    public void PlayerWon()
    {
        m_winner = new BeyBladeAfterBattle(player, winnerTarget, time);
        m_losser = new BeyBladeAfterBattle(enemy, looserTarget, time);
        StartCoroutine(RaiseBeyBlades());
        Debug.Log("Player Won");
    }
    public void EnemyWon()
    {
        m_winner = new BeyBladeAfterBattle(enemy, winnerTarget, time);
        m_losser = new BeyBladeAfterBattle(player, looserTarget, time);
        StartCoroutine(RaiseBeyBlades());
        Debug.Log("Enemy Won");
    }

    private void Update()
    {
        CheckAndRaiseFinishEvent();
        SendBeyBladesToTheirTarget();
    }

    IEnumerator RaiseBeyBlades()
    {
        yield return new WaitForSeconds(waitTime);
        m_animationStarted = true;
    }
    private void CheckAndRaiseFinishEvent()
    {
        if (m_animationFinished && !m_FinishEventRaised)
        {
            Debug.Log("Beyblades rose above ground");
            m_FinishEventRaised = true;
            OnBeyBladesRisedAboveGround?.Invoke(m_losser.gameObject, m_winner.gameObject);
        }
    }

    private void SendBeyBladesToTheirTarget()
    {
        if (m_animationStarted == false || m_animationFinished == true)
            return;
        if (m_winner.hasReachedTarget && m_losser.hasReachedTarget)
        {
            m_animationFinished = true;
            return;
        }
        Debug.Log("Send beyblades towards target");
        MoveTowardsTarget(m_winner);
        MoveTowardsTarget(m_losser);
    }

    private void MoveTowardsTarget(BeyBladeAfterBattle _beyBlade)
    {
        if (!m_animationStarted)
        {
            return;
        }
        if(_beyBlade.gameObject.GetComponent<Collider>().bounds.Intersects(_beyBlade.targetCollider.bounds))
        {
            _beyBlade.hasReachedTarget = true;
            return;
        }
        Vector3 increment = _beyBlade.velocityMultiplier * Time.deltaTime * (_beyBlade.TargetPosition - _beyBlade.Position).normalized;
        _beyBlade.Position += increment.magnitude * increment.normalized;
    }
 }
[System.Serializable]
public class BeyBladeAfterBattle
{
    public GameObject gameObject;
    public Collider targetCollider;
    public bool hasReachedTarget = false;
    public float velocityMultiplier;
    public Vector3 TargetPosition
    {
            get=> targetCollider.transform.position;
        
    }
    public Vector3 Position
    {
        get => gameObject.transform.position;
        set
        {
            gameObject.transform.position = value;
            //Debug.Log("Final Pos = " + gameObject.transform.position); 
        }
    }
    public BeyBladeAfterBattle(GameObject gameObject, Collider targetCollider, float _time)
    {
        this.gameObject = gameObject;
        this.targetCollider = targetCollider;
        velocityMultiplier = Vector3.Distance(Position, TargetPosition) / _time;
    }
}