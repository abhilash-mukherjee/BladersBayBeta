using UnityEngine;

public abstract class BaseCollisionProcessor: MonoBehaviour
{
    public delegate void CollisionPhysicsHandler(ICollision collision);
    public delegate void CollisionHealthHandler(ICollision collision);
    public static event CollisionPhysicsHandler OnCollisionPhysicsProcessed;
    public static event CollisionHealthHandler OnCollisionHealthProcessed;
    private void OnEnable()
    {
        CollisionChecker.OnCollided += ProcessCollision;
    }
    private void OnDisable()
    {
        CollisionChecker.OnCollided -= ProcessCollision;
    }
    protected abstract void ProcessCollision(ICollision collision);
    protected void InvokePhysicsProcessorEvent(ICollision collision)
    {
        OnCollisionPhysicsProcessed?.Invoke(collision);
    }
    protected void InvokeHealthProcessorEvent(ICollision collision)
    {
        OnCollisionHealthProcessed?.Invoke(collision);
    }
}
