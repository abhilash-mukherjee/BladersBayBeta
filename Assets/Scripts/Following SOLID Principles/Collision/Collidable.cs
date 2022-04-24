using UnityEngine;

public abstract class Collidable : MonoBehaviour
{
    public abstract Collider Collider { get; }
    public abstract float GetAngleBetweenDirectionOfVelocityAndPassedVector(Vector3 _lineOfImpactThisToOther);
    public abstract Vector3 GetVelocity();
    public abstract Transform Transform { get; }
    public abstract GameObject GameObject { get; }
    public abstract CharacterController CharacterController { get; }
    public abstract BaseData CurrentStats { get; }

}

