using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthManager : MonoBehaviour
{
    public delegate void DeathHandler(GameObject gameObject);
    public static event DeathHandler OnDied;
    protected abstract float DamageValue { get; }
    protected abstract float HealthPoint { get; set; }
    protected abstract void HasAttcked(GameObject _gameObject, float _collisionIndex);
    protected abstract void HasGotHit(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue);
    private void OnEnable()
    {
        CollisionHealthResponder.OnObjectIsAttacker += HasAttcked;
        CollisionHealthResponder.OnObjectIsVictim += HasGotHit;
    }
    private void OnDisable()
    {
        CollisionHealthResponder.OnObjectIsAttacker -= HasAttcked;
        CollisionHealthResponder.OnObjectIsVictim -= HasGotHit;
    }
    protected void RaiseDiedEvent(GameObject _gameObject)
    {
        OnDied(_gameObject);
    }
}
