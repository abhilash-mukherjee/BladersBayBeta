using UnityEngine;

public class CollidingBeyBlade : ICollidingBeyBlade
{
    private CharacterController m_controller;
    private GameObject m_beyBladeObject;
    private Vector3 m_position;
    private Vector3 m_directionVectorToOtherBeyBlade;
    private Vector3 m_velocityBeforeCollision;
    private Vector3 m_velocityAfterCollision;
    private float m_collisionAngle;
    public CharacterController Controller { get => m_controller; }
    public Vector3 Position { get => m_position; }
    public Vector3 DirectionVectorToOtherBeyBlade { get => m_directionVectorToOtherBeyBlade; }
    public float CollisionAngle { get => m_collisionAngle; }
    public Vector3 VelocityBeforeCollision { get => m_velocityBeforeCollision; }
    public Vector3 VelocityAfterCollision { get => m_velocityAfterCollision; }
    public GameObject BeyBladeObject { get => m_beyBladeObject; }

    public CollidingBeyBlade(CharacterController _controller, Vector3 _position, Vector3 _directionVectorToOtherBeyBlade, CharacterController _otherController,
        float _staticCollisionVelocityLimit, float _staticCollisionVelociyMultiplier)
    {
        m_beyBladeObject = _controller.gameObject;
        m_controller = _controller;
        m_position = _position;
        m_directionVectorToOtherBeyBlade = _directionVectorToOtherBeyBlade;
        m_velocityBeforeCollision = _controller.velocity;
        m_collisionAngle = FindAngleBetweenVelocityAndSeperationVector(m_controller, m_directionVectorToOtherBeyBlade);
        m_velocityAfterCollision = CalculateInitialVelocityAfterCollision(_otherController.velocity, -1f * _directionVectorToOtherBeyBlade,
            _staticCollisionVelocityLimit, _staticCollisionVelociyMultiplier);
    }

    private float FindAngleBetweenVelocityAndSeperationVector(CharacterController _controller, Vector3 _dir)
    {
        var _vel = _controller.velocity;
        Debug.DrawRay(_controller.gameObject.transform.position, _vel, Color.green, 30f, true);
        var _angle = Vector3.Angle(_dir, _vel);
        if (_vel.magnitude <= 0.01f)
        {
            _angle = 180f;
        }
        Debug.DrawRay(_controller.gameObject.transform.position, _dir * 5f, Color.blue, 30f, true);
        return _angle;
    }

    protected virtual Vector3 CalculateInitialVelocityAfterCollision(Vector3 _otherVelocity, Vector3 _directionVectorOtherToThis,
        float _staticCollisionVelocityLimit, float _staticCollisionVelociyMultiplier)
    {
        _directionVectorOtherToThis.Normalize();
        Vector3 _normalVelocity = Vector3.Dot(_directionVectorOtherToThis, _otherVelocity) * _directionVectorOtherToThis;
        Vector3 _directionVectorThisToOther = -1f * _directionVectorOtherToThis;
        Vector3 _vel = m_controller.velocity;
        float _angleInDegrees = Vector3.Angle(_directionVectorThisToOther, _vel); ;
        float _angleInRadian = (Mathf.PI * _angleInDegrees / 180f);
        Vector3 _tangentialVelocity = m_controller.velocity
            - m_controller.velocity.magnitude * Mathf.Cos(_angleInRadian) * _directionVectorThisToOther;
        Vector3 _velAfterCollision = _normalVelocity + _tangentialVelocity;
        if (_velAfterCollision.magnitude <= _staticCollisionVelocityLimit)
        {
            Debug.Log("Colliding beyblade velocity multiplied");
            _velAfterCollision = _directionVectorOtherToThis * _staticCollisionVelociyMultiplier;
        }
        return _velAfterCollision;
    }
}
