using UnityEngine;

public interface ICollidingBeyBlade
{
    GameObject BeyBladeObject { get; }
    float CollisionAngle { get; }
    CharacterController Controller { get; }
    Vector3 DirectionVectorToOtherBeyBlade { get; }
    Vector3 Position { get; }
    Vector3 VelocityAfterCollision { get; }
    Vector3 VelocityBeforeCollision { get; }
}
