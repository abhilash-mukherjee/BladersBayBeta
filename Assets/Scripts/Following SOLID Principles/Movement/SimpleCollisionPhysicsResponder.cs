using UnityEngine;

public class SimpleCollisionPhysicsResponder : CollisionPhysicsResponder
{
    
    [SerializeField]
    private CollisionVelocityDecider collisionVelocityDecider;
    [SerializeField]
    private TimeVariable collisionPhaseTime;
    protected override void OnPhysicsProcessed(GameObject _gameObject, Vector3 _finalVelAfterCollision)
    {
        if (_gameObject != gameObject) return;
        RaiseOnControlChangedEvent(this.gameObject);
        RaiseOnVelocityChangedEvent(this.gameObject,_finalVelAfterCollision);
    }
}