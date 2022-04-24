using UnityEngine;

public abstract class CollisionHealthProcessor : MonoBehaviour
{
    public delegate void HealthAfterAttackingHandler(GameObject _gameObject, float _collisionIndex);
    public delegate void HealthAfterGettingDamagedHandler(GameObject _gameObject, float _collisionIndex, float opponentAttackValue);
    public static event HealthAfterAttackingHandler OnGameObjectAttacker;
    public static event HealthAfterGettingDamagedHandler OnGameObjectVictim;
    protected abstract void ProcessHealth(ICollision collision);
    private void OnEnable()
    {
        BaseCollisionProcessor.OnCollisionHealthProcessed += ProcessHealth;
    }
    private void OnDisable()
    {
        BaseCollisionProcessor.OnCollisionHealthProcessed -= ProcessHealth;
    }
    protected void RaiseGameObjectAttckerEvent(GameObject _gameObject, float _collisionIndex)
    {
        OnGameObjectAttacker?.Invoke(_gameObject, _collisionIndex);
    }
    protected void RaiseGameObjectVictimEvent(GameObject _gameObject, float _collisionIndex,  float _opponentAttackValue)
    {
        OnGameObjectVictim?.Invoke(_gameObject, _collisionIndex, _opponentAttackValue);
    }
}
