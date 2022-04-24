using UnityEngine;
public abstract class CollisionHealthResponder : MonoBehaviour
{

    public delegate void IsAttackerEventHandler(GameObject gameObject, float _collisionIndex);
    public delegate void IsVictimEventHandler(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue);
    public static event IsAttackerEventHandler OnObjectIsAttacker;
    public static event IsVictimEventHandler OnObjectIsVictim;
    private void OnEnable()
    {
        CollisionHealthProcessor.OnGameObjectAttacker += IsAttacker;
        CollisionHealthProcessor.OnGameObjectVictim += IsVictim;
    }
    private void OnDisable()
    {
        CollisionHealthProcessor.OnGameObjectAttacker -= IsAttacker;
        CollisionHealthProcessor.OnGameObjectVictim -= IsVictim;
    }
    protected abstract void IsAttacker(GameObject _gameObject, float _collisionIndex);
    protected abstract void IsVictim(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue);
    protected void RaiseIsAttackerEvent(GameObject _gameObject, float _collisionIndex)
    {
        OnObjectIsAttacker?.Invoke(_gameObject, _collisionIndex);
    }
    protected void RaiseIsVictimEvent(GameObject _gameObject, float _collisionIndex, float _opponentAttackValue)
    {
        OnObjectIsVictim?.Invoke(_gameObject, _collisionIndex, _opponentAttackValue);
    }
}
