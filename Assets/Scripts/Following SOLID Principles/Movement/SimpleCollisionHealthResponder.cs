using UnityEngine;

public class SimpleCollisionHealthResponder : CollisionHealthResponder
{

    protected override void IsAttacker(GameObject _gameObject, float _collisionIndex)
    {
        if (_gameObject != gameObject)
            return;
        RaiseIsAttackerEvent(_gameObject, _collisionIndex);
    }

    protected override void IsVictim(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue)
    {
        if (_gameObject != gameObject)
            return;
        RaiseIsVictimEvent(_gameObject, _collisionIndex, _opponentAttackValue);
    }
}
