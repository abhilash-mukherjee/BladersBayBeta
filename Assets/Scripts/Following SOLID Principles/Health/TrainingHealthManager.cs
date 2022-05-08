using UnityEngine;

public class TrainingHealthManager : HealthManager
{
    [SerializeField]
    private BaseData currentStatHolder;
    [SerializeField]
    private FloatVariable healthPoint;
    private bool m_eventRaised = false;
    protected override float DamageValue { get =>currentStatHolder.DamageValue; }
    protected override float HealthPoint 
    { 
        get => healthPoint.Value;
        set
        {
            healthPoint.Value = value;
           

        }
    }

    private void OnEnable()
    {
        CollisionHealthResponder.OnObjectIsAttacker += HasAttcked;
        CollisionHealthResponder.OnObjectIsVictim += HasGotHit;
        Debug.Log("OnEnable called of trainingHealthManager");
        m_eventRaised = false;
    }
    private void OnDisable()
    {
        CollisionHealthResponder.OnObjectIsAttacker -= HasAttcked;
        CollisionHealthResponder.OnObjectIsVictim -= HasGotHit;
    }
    private void Awake()
    {
        HealthPoint = 100f;
    }
    protected override void HasAttcked(GameObject _gameObject, float _collisionIndex)
    {
        if (_gameObject != gameObject)
        {
            return;
        }
    }
    private void Update()
    {
        if (healthPoint.Value <= 0f && !m_eventRaised) 
        {
            StartRaiseDiedEventCoroutine(gameObject);
            Debug.Log("Death event raised for " + gameObject);
            m_eventRaised = true;
        }
    }
    protected override void HasGotHit(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue)
    {
        if (_gameObject != gameObject)
        {
            return;
        }
        Debug.Log($"Dmg value = {DamageValue}, Opponent Attack Value = {_opponentAttackValue}, Collision Index = {_collisionIndex} Total = {_collisionIndex * _opponentAttackValue * DamageValue}");
        HealthPoint -= _collisionIndex * DamageValue * _opponentAttackValue;
    }
}