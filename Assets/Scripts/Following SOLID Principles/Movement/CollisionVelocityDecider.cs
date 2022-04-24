using UnityEngine;

public class CollisionVelocityDecider : VelocityDecider
{
    [SerializeField]
    private float collisionDecellerationRate;
    [SerializeField]
    private float minValueForVelocity = 0.001f;
    [SerializeField]
    private MoveVelocityDecidedByCollisionVelocityDecider decidedVelocity;
    private Vector3 m_velocity = Vector3.zero;
    private Vector3 M_Velocity { get => m_velocity; set => m_velocity = value.magnitude <= 0.001 ? Vector3.zero : value; }
    protected override MovementVelocityVector DecidedVelocity { get => decidedVelocity; set => decidedVelocity.SetValue(value.Value.x, value.Value.y, value.Value.z); }

    private void OnEnable()
    {
        CollisionPhysicsResponder.OnVelocityChanged += OnVelocityChanged;
    }
    private void OnDisable()
    {
        
        CollisionPhysicsResponder.OnVelocityChanged -= OnVelocityChanged;
    }
    private void OnVelocityChanged(GameObject gameObject, Vector3 _finalVelAfterCollision)
    {
        if (gameObject != this.gameObject) return;
        M_Velocity = _finalVelAfterCollision;
    }
    private Vector3 DecellerateVelocity()
    {
        var _dir = M_Velocity;
        _dir.Normalize();
        float _mag = M_Velocity.magnitude;
        _mag -= collisionDecellerationRate * Time.deltaTime;
        return _mag * _dir;
    }

    protected override Vector3 UpdateVelocity(Vector3 input)
    {
        M_Velocity = DecellerateVelocity();
        return M_Velocity;
    }
}
