using UnityEngine;

public class CustomCollision : ICollision
{
    private readonly Collidable collidable1, collidable2;
    public Collidable Collidable1 { get => collidable1; }
    public Collidable Collidable2 { get => collidable2; }

    public float AngleOfCollision1 { get => angle1; }
    public float AngleOfCollision2 { get => angle2; }

    public Vector3 VelocityBeforeCollision1 { get => velBeforeCol1; }
    public Vector3 VelocityBeforeCollision2 { get => velBeforeCol2; }

    public Vector3 DirectionVector1To2 { get => directionVector1To2; }
    public Vector3 DirectionVector2To1 { get => directionVector2To1; }

    public float CollisionAngle { get => collisionAngle; }

    private readonly float angle1, angle2, collisionAngle;
    private readonly Vector3 velBeforeCol1, velBeforeCol2;
    private readonly Vector3 directionVector1To2, directionVector2To1;
    public CustomCollision(Collidable collidable1, Collidable collidable2)
    {
        this.collidable1 = collidable1;
        this.collidable2 = collidable2;
        angle1 = collidable1.GetAngleBetweenDirectionOfVelocityAndPassedVector(collidable2.Transform.position - collidable1.Transform.position); 
        angle2 = collidable2.GetAngleBetweenDirectionOfVelocityAndPassedVector(collidable1.Transform.position - collidable2.Transform.position);
        collisionAngle = Mathf.Abs(angle1 - angle2);
        velBeforeCol1 = collidable1.GetVelocity();
        velBeforeCol2 = collidable2.GetVelocity();
        directionVector1To2 = (collidable2.Transform.position - collidable1.transform.position).normalized;
        directionVector2To1 = (collidable1.Transform.position - collidable2.transform.position).normalized;
    }
}