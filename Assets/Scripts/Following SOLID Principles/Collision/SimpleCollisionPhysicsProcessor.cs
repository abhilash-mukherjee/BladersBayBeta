using UnityEngine;

public class SimpleCollisionPhysicsProcessor : CollisionPhysicsProcessor
{
    [SerializeField]
    [Tooltip("Minimum velocity possessed by a beyblade below which beyblade is considered static while colliding")]
    private float staticCollisionVelocityLimit = 0.01f;
    [SerializeField]
    [Tooltip("Multiplying factor to a beyblade's final velocity after collision when it is static")]
    private float staticCollisionVelocityMultiplier = 1f;
    [SerializeField]
    private float timeOfCollisionPhase = 1f;

    protected override void ProcessPhysics(ICollision collision)
    {
        var vel1 = CalculateInitialVelocityAfterCollision(collision.VelocityBeforeCollision1,
            collision.VelocityBeforeCollision2, 
            collision.DirectionVector2To1);
        var vel2 = CalculateInitialVelocityAfterCollision(collision.VelocityBeforeCollision2,
            collision.VelocityBeforeCollision1, 
            collision.DirectionVector1To2);
        InvokeVelocityChangedEvent(collision.Collidable2.GameObject, timeOfCollisionPhase, vel2);
        InvokeVelocityChangedEvent(collision.Collidable1.GameObject,timeOfCollisionPhase, vel1);
    }

    protected virtual Vector3 CalculateInitialVelocityAfterCollision(Vector3 _thisVelocityBeforeCollision, Vector3 _otherVelocity, Vector3 _directionVectorOtherToThis)
    {
        _directionVectorOtherToThis.Normalize();
        Vector3 _normalVelocity = Vector3.Dot(_directionVectorOtherToThis, _otherVelocity) * _directionVectorOtherToThis;
        Vector3 _directionVectorThisToOther = -1f * _directionVectorOtherToThis;
        Vector3 _vel = _thisVelocityBeforeCollision;
        float _angleInDegrees = Vector3.Angle(_directionVectorThisToOther, _vel); ;
        float _angleInRadian = (Mathf.PI * _angleInDegrees / 180f);
        Vector3 _tangentialVelocity = _thisVelocityBeforeCollision
            - _thisVelocityBeforeCollision.magnitude * Mathf.Cos(_angleInRadian) * _directionVectorThisToOther;
        Vector3 _velAfterCollision = _normalVelocity + _tangentialVelocity;
        if (_velAfterCollision.magnitude <= staticCollisionVelocityLimit)
        {
            Debug.Log("Colliding beyblade velocity multiplied");
            _velAfterCollision = _directionVectorOtherToThis * staticCollisionVelocityMultiplier;
        }
        return _velAfterCollision;
    }
}
