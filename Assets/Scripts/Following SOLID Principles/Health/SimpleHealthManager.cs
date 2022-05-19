using UnityEngine;

public class SimpleHealthManager : HealthManager
{
    [SerializeField]
    private BaseData currentStatHolder;
    [SerializeField]
    private FloatVariable healthPoint;
    private bool m_hasEventRaised = false;

    protected override float DamageValue { get =>currentStatHolder.DamageValue; }
    protected override float HealthPoint 
    { 
        get => healthPoint.Value;
        set
        {
            healthPoint.Value = value;
           

        }
    }

    private void Awake()
    {
        HealthPoint = 100f;
    }

    protected override void HasAttcked(GameObject _gameObject, float _collisionIndex)
    {
        if (_gameObject != gameObject)
            return;
    }
    private void Update()
    {
        if (healthPoint.Value <= 0f && !EventRaised) 
        {
            StartRaiseDiedEventCoroutine(gameObject);
            Debug.Log("Death event raised for " + gameObject);
            EventRaised = true;
            m_hasEventRaised = false;
}
    }
    protected override void HasGotHit(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue)
    {
        if (_gameObject != gameObject)
            return;
        Debug.Log("Dmg value = " + DamageValue);
        HealthPoint -= _collisionIndex * DamageValue * _opponentAttackValue;
    }

    protected override void ChildOnEnable()
    {
        EventRaised = false;
    }
}
