using UnityEngine;

public abstract class CollisionPhysicsResponder : MonoBehaviour
{
    public delegate void PostCollisionControlHandler(GameObject gameObject);
    public delegate void PostCollisionVelocityHandler(GameObject gameObject, Vector3 _finalVelocity);
    public delegate void PostCollisionHealthHandler(GameObject gameObject, Vector3 _finalVelocity);
    public static event PostCollisionControlHandler OnControlChanged;
    public static event PostCollisionVelocityHandler OnVelocityChanged;
    private void OnEnable()
    {
        CollisionPhysicsProcessor.OnCollisionPhysicsProcessed += OnPhysicsProcessed;
    }
    private void OnDisable()
    {
        CollisionPhysicsProcessor.OnCollisionPhysicsProcessed -= OnPhysicsProcessed;
       
    }
    protected abstract void OnPhysicsProcessed(GameObject _gameObject, Vector3 _finalVelAfterCollision);
    protected void RaiseOnControlChangedEvent(GameObject gameObject)
    {
        OnControlChanged?.Invoke(gameObject);
    }
    protected void RaiseOnVelocityChangedEvent(GameObject gameObject, Vector3 velocity)
    {
        OnVelocityChanged?.Invoke(gameObject,velocity);
    }
}
