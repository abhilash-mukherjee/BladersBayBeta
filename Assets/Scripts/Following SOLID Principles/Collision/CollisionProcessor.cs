using UnityEngine;

public class CollisionProcessor : BaseCollisionProcessor
{
    [SerializeField]
    private float safeDistanceForGlitchFreeBehaviour = 0.18f;
    protected override void ProcessCollision(ICollision collision)
    {
        var col1 = collision.Collidable1;
        var col2 = collision.Collidable2;
        if (CheckForGlitch(col1, col2))
        {
            InvokePhysicsProcessorEvent(collision);
            Debug.Log("Collision with Glitch");
            return;
        }
        Debug.Log("Normal Collision");
        InvokeHealthProcessorEvent(collision);
        InvokePhysicsProcessorEvent(collision);
    }
    private bool CheckForGlitch(Collidable col1, Collidable col2)
    {
        if (Vector3.Distance(col1.Transform.position, col2.Transform.position) <= safeDistanceForGlitchFreeBehaviour)
        {
            return true;
        }
        else return false;

    }
}