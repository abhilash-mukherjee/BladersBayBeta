using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StateController))]
public class BeyBladeHealthManager : MonoBehaviour
{
    public delegate void ImpactMAnager(StateController _stateController, float _collisionIndex);
    public delegate void BattleEndManager(GameObject _gameObject);
    public static event ImpactMAnager OnBeyBladeAttacked, OnBeyBladeDamaged, OnBeyBladeCollided;
    public static event BattleEndManager OnBattleEnd;
    [SerializeField]
    private StateController stateController;
    [SerializeField]
    private FloatReference maxHealth;
    [SerializeField][Tooltip("The constant tat gets multiplied to damage value")]
    [Range(0f,10f)]
    private float damageConstant = 5f;
    [SerializeField]
    [Tooltip("The constant tat gets multiplied to stamina value")]
    private float staminaConstant;
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
            else if (value >= maxHealth.Value)
            {
                currentHealth.Value = maxHealth.Value;
            }
            else
                currentHealth.Value = value; 
        }
    }

    private void OnEnable()
    {
        CollisionManager1.OnBeyBladesCollidedNormally += HandleHealthAfterCollision;
        m_CurrentHealth = maxHealth.Value;
    }

    private void OnDisable()
    {
        CollisionManager1.OnBeyBladesCollidedNormally -= HandleHealthAfterCollision;
    }

    private void Update()
    {
        if(stateController.CurrentState == null)
        {
            Debug.LogError("Current state is null");
            return;
        }
        Debug.Log(stateController.CurrentState);
        m_CurrentHealth += stateController.CurrentState.Data.StaminaValue * Time.deltaTime * staminaConstant;
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
                RaiseDefenceEvent(_Collision.CollisionIndex);
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
                RaiseAttackEvent(_Collision.CollisionIndex);
                float _dmg = CalculateDamageWhileAttacking(_Collision.CollisionIndex, _victim);
                m_CurrentHealth -= _dmg;
            }
        }
        RaiseCollisionEvent(_Collision.CollisionIndex);
        
    }

    private void RaiseAttackEvent(float collisionIndex)
    {
        OnBeyBladeAttacked?.Invoke(stateController,collisionIndex);
    }
    private void RaiseDefenceEvent(float collisionIndex)
    {
        OnBeyBladeDamaged?.Invoke(stateController,collisionIndex);
    }
    private void RaiseCollisionEvent(float collisionIndex)
    {
        OnBeyBladeCollided?.Invoke(stateController,collisionIndex);
    }

    private float CalculateDamageWhileAttacking(float _collisionIndex, GameObject _victim)
    {
        float _dmg = damageConstant * _victim.GetComponent<StateController>().CurrentState.Data.DefenceValue * stateController.CurrentState.Data.DamageValue * _collisionIndex;
        return _dmg;
    }

    private float CalculateDamageWhileDefending(float _collisionIndex, GameObject _attacker)
    {
        float _dmg = damageConstant * _attacker.GetComponent<StateController>().CurrentState.Data.AttackValue * stateController.CurrentState.Data.DamageValue * _collisionIndex;
        return _dmg;
    }

    public bool HasDied()
    {
        if (m_CurrentHealth <= Mathf.Epsilon)
            return true;
        else return false;
    }

    public void MaximizeHealth()
    {
        m_CurrentHealth = maxHealth.Value;
    }
}

