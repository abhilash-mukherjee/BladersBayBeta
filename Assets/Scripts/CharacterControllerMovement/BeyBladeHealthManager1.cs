using UnityEngine;

public class BeyBladeHealthManager1 : MonoBehaviour
{
    public delegate void BattleEndManager(GameObject _gameObject);
    public static event BattleEndManager OnBattleEnd;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private FloatVariable currentHealth;
    private float m_CurrentHealth { get => currentHealth.Value; 
        set 
        {
            if (value <= 0f)
            {
                currentHealth.Value =  0.001f;
                OnBattleEnd?.Invoke(gameObject);
            }
            else if (value >= maxHealth)
            {
                currentHealth.Value = maxHealth;
            }
            else
                currentHealth.Value = value; 
        }
    }

    private void OnEnable()
    {
        CollisionManager1.OnBeyBladesCollidedNormally += HandleHealthAfterCollision;
        m_CurrentHealth = maxHealth;
    }

    private void OnDisable()
    {
        CollisionManager1.OnBeyBladesCollidedNormally -= HandleHealthAfterCollision;
    }

    private void Update()
    {
    }
    private  void HandleHealthAfterCollision(INormalCollision _Collision)
    {
        if (_Collision.IsAttacker(gameObject) == false && _Collision.IsVictim(gameObject) == false)
        {
            Debug.Log("Neither Attacker Nor Victim");
            return;
        }
        if(_Collision.IsVictim (gameObject))
        {
            var _attacker = _Collision.GetAttacker(gameObject);
            if (_attacker == null)
            {
                Debug.Log("No attacker found");
            }
            else
            {
                float _dmg = CalculateDamageWhileDefending(_Collision.CollisionIndex, _attacker);
                m_CurrentHealth -= _dmg;
            }

        }
        if (_Collision.IsAttacker(gameObject))
        {
            Debug.Log($"{gameObject} has attacked");
            var _victim = _Collision.GetVictim(gameObject);
            if (_victim == null)
            {
                Debug.Log("No victim found");
            }
            else
            {
                Debug.Log($"Attack registered for {gameObject}");
                float _dmg = CalculateDamageWhileAttacking(_Collision.CollisionIndex, _victim);
                m_CurrentHealth -= _dmg;
            }
        }
        
    }


    private float CalculateDamageWhileAttacking(float _collisionIndex, GameObject _victim)
    {
        return 0f;
    }

    private float CalculateDamageWhileDefending(float _collisionIndex, GameObject _attacker)
    {
        return 0f;
    }

    public bool HasDied()
    {
        if (m_CurrentHealth <= Mathf.Epsilon)
            return true;
        else return false;
    }

    public void MaximizeHealth()
    {
        m_CurrentHealth = maxHealth;
    }
}

