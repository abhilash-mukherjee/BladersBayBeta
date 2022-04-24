using System.Collections.Generic;
using UnityEngine;

public class BeyBladeCollision : INormalCollision
{
    protected ICollidingBeyBlade m_beyBlade1, m_beyBlade2;
    public ICollidingBeyBlade BeyBlade1 { get => m_beyBlade1; }
    public ICollidingBeyBlade BeyBlade2 { get => m_beyBlade2; }
    public float AngleDifference { get => m_angleDifference; }
    public float CollisionIndex { get => m_collisionIndex; }

    protected List<ICollidingBeyBlade> attackers, victims;
    protected float m_collisionIndex = 0;
    protected float m_angleDifference = 180;
    protected float m_collisionVelocityMultiplier = 1f;
    protected float m_staticCollisionVelocityLimit;
    protected float m_staticCollisionVelocityMultiplier;
    protected BeyBladeCollisionType m_collisionType;

    public BeyBladeCollision(GameObject _player1, GameObject _player2, List<BeyBladeCollisionType> _collisionTypes,
        float _collisionVelocityMultiplier, float _staticCollisionVelocityLimit, float _staticCollisionVelociyMultiplier)
    {
        m_beyBlade1 = new CollidingBeyBlade(_player1.GetComponent<CharacterController>(), _player1.transform.position,
            _player2.transform.position - _player1.transform.position, _player2.GetComponent<CharacterController>(),
            _staticCollisionVelocityLimit, _staticCollisionVelociyMultiplier);
        m_beyBlade2 = new CollidingBeyBlade(_player2.GetComponent<CharacterController>(), _player2.transform.position,
            _player1.transform.position - _player2.transform.position, _player1.GetComponent<CharacterController>(),
            _staticCollisionVelocityLimit, _staticCollisionVelociyMultiplier);
        m_angleDifference = CalculateAngleDifference();
        m_collisionType = GetCollisionType(_collisionTypes);
        if (m_collisionType == null)
            return;
        victims = m_collisionType.GetVictim(this);
        if (victims.Count != 0)
        {
            Debug.Log("Victim count nonZero");
            attackers = m_collisionType.GetAttacker(this);
        }
        if (attackers.Count != 0)
            m_collisionIndex = CalculateCollisionIndex();
        m_collisionVelocityMultiplier = _collisionVelocityMultiplier;
    }


    private float CalculateAngleDifference()
    {
        if (m_beyBlade1.VelocityBeforeCollision.magnitude == 0f || m_beyBlade2.VelocityBeforeCollision.magnitude == 0f)
        {
            return 180f;
        }
        else
        {
            var _Angle = (m_beyBlade1.CollisionAngle - m_beyBlade2.CollisionAngle);
            _Angle = _Angle > 0 ? _Angle : -1f * _Angle;
            return _Angle;
        }
    }

    public virtual Vector3 GetVelocityAfterCollision(GameObject _gameObject)
    {
        if (m_beyBlade1.BeyBladeObject == _gameObject)
        {
            return m_beyBlade1.VelocityAfterCollision * m_collisionVelocityMultiplier;
        }
        else if (m_beyBlade2.BeyBladeObject == _gameObject)
            return m_beyBlade2.VelocityAfterCollision * m_collisionVelocityMultiplier;
        else return Vector3.zero;
    }
    public virtual bool CheckIfPassedGameObjectIsInvolvedInCollision(GameObject _gameObject)
    {
        if (m_beyBlade1.BeyBladeObject == _gameObject || m_beyBlade2.BeyBladeObject == _gameObject)
            return true;
        else
            return false;
    }
    private BeyBladeCollisionType GetCollisionType(List<BeyBladeCollisionType> _collisionTypes)
    {
        foreach (var _type in _collisionTypes)
        {
            if (_type.CheckCondition(this))
                return _type;
        }
        return null;
    }
    private float CalculateCollisionIndex()
    {
        return m_collisionType.CollisionIndex;
    }

    public virtual bool IsAttacker(GameObject _gameObject)
    {
        var a = attackers.Find(p => p.BeyBladeObject == _gameObject);
        if (a == null)
            return false;
        else return true;
    }
    public virtual bool IsVictim(GameObject _gameObject)
    {
        var v = victims.Find(p => p.BeyBladeObject == _gameObject);
        if (v == null)
            return false;
        else return true;
    }

    public virtual GameObject GetVictim(GameObject _attackerObject)
    {
        var _beyBlade = victims.Find(p => p.BeyBladeObject != _attackerObject);
        if (_beyBlade != null)
            return _beyBlade.BeyBladeObject;
        else
            return null;
    }
    public virtual GameObject GetAttacker(GameObject _victimObject)
    {
        var _beyBlade = attackers.Find(p => p.BeyBladeObject != _victimObject);
        if (_beyBlade != null)
            return _beyBlade.BeyBladeObject;
        else
            return null;
    }
}
