using UnityEngine;
public interface ICollision
{
    Collidable Collidable1 { get; }
    Collidable Collidable2 { get; }
    float AngleOfCollision1 { get; }
    float AngleOfCollision2 { get; }
    float CollisionAngle { get; }
    public Vector3 DirectionVector1To2 { get; }
    public Vector3 DirectionVector2To1 { get; }
    Vector3 VelocityBeforeCollision1 { get; }
    Vector3 VelocityBeforeCollision2 { get; }
}