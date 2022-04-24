using UnityEngine;

public abstract class CollisionPhysicsProcessor : MonoBehaviour
{
    public delegate void VelocityAfterCollisionHandler(GameObject _gameObject, Vector3 _finalVelAfterCollision);
    public static event VelocityAfterCollisionHandler OnCollisionPhysicsProcessed;
    protected abstract void ProcessPhysics(ICollision collision);
    private void OnEnable()
    {
        BaseCollisionProcessor.OnCollisionPhysicsProcessed += ProcessPhysics;
    }
    private void OnDisable()
    {
        BaseCollisionProcessor.OnCollisionPhysicsProcessed -= ProcessPhysics;
    }
    protected void InvokeVelocityChangedEvent(GameObject _gameObject, float _timeOfCollisionPhase, Vector3 _finalVelAfterCollision)
    {
        OnCollisionPhysicsProcessed?.Invoke( _gameObject,  _finalVelAfterCollision);
    }
}
