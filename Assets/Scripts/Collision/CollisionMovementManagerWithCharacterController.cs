using UnityEngine;

public class CollisionMovementManagerWithCharacterController : MovementManagerWithCharacterController
{
    [SerializeField]
    private BeyBladeCollisionPhysicsManager collisionPhysicsManager;
    [SerializeField]
    private float collisionDecellerationRate;
    private Vector3 m_velocity;
    private void OnEnable()
    {
        m_characterController = GetComponent<CharacterController>();
        m_velocity = collisionPhysicsManager.InitialVelocityAfterCollision;
    }
    protected override void Awake()
    {
        base.Awake();
        m_type = this.GetType();
    }
    protected override Vector3 CalculateMovement()
    {
        m_velocity = DecellerateVelocity();
        return m_velocity;
    }

    private Vector3 DecellerateVelocity()
    {
        var _dir = m_velocity;
        _dir.Normalize();
        float _mag = m_velocity.magnitude;
        _mag -= collisionDecellerationRate * Time.deltaTime;
        return _mag * _dir;
    }
}
