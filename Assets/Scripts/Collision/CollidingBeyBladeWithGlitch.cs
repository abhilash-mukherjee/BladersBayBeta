using UnityEngine;

public class CollidingBeyBladeWithGlitch : ICollidingBeyBlade
{
    private CharacterController m_controller;
    private GameObject m_beyBladeObject;
    private Vector3 m_position;
    private Vector3 m_directionVectorToOtherBeyBlade;
    private Vector3 m_velocityBeforeCollision;
    private Vector3 m_velocityAfterCollision;
    private float m_collisionAngle;

    public GameObject BeyBladeObject { get => m_beyBladeObject; }

    public float CollisionAngle { get => m_collisionAngle; }

    public CharacterController Controller { get=>m_controller; }

    public Vector3 DirectionVectorToOtherBeyBlade { get=>m_directionVectorToOtherBeyBlade; }

    public Vector3 Position { get=>m_position; }

    public Vector3 VelocityAfterCollision { get=>m_velocityAfterCollision; }

    public Vector3 VelocityBeforeCollision { get=>m_velocityBeforeCollision; }

    public CollidingBeyBladeWithGlitch(CharacterController _controller, Vector3 _position, Vector3 _directionVectorToOtherBeyBlade)
    { 
        m_beyBladeObject = _controller.gameObject;
        m_controller = _controller;
        m_position = _position;
        m_directionVectorToOtherBeyBlade = _directionVectorToOtherBeyBlade;
        m_velocityBeforeCollision = _controller.velocity;
        m_collisionAngle = FindAngleBetweenVelocityAndSeperationVector(m_controller, m_directionVectorToOtherBeyBlade);
        m_velocityAfterCollision = CalculateInitialVelocityAfterCollision( -1f *_directionVectorToOtherBeyBlade);
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

    private  Vector3 CalculateInitialVelocityAfterCollision(Vector3 _directionVectorOtherToThis)
    {
        _directionVectorOtherToThis.Normalize();
        Debug.Log("Colliding beyblade velocity multiplied");
        Vector3 _velAfterCollision = _directionVectorOtherToThis * 1f; ;
        return _velAfterCollision;
    }
}