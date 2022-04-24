using UnityEngine;

public class CollidableBeyBlade : Collidable
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private Collider capsulrCollider;
    [SerializeField]
    private float deltaVelocity = 0001f;
    [SerializeField]
    private BaseData currentStats;
    public override Collider Collider { get=> capsulrCollider; }
    public override float GetAngleBetweenDirectionOfVelocityAndPassedVector(Vector3 _otherVector)
    {
        if (characterController.velocity.magnitude <= deltaVelocity) return 180f;
        else return Mathf.Abs(Vector3.Angle(characterController.velocity,_otherVector));
    }
    public override Vector3 GetVelocity() => characterController.velocity;
    public override Transform Transform { get=>transform; }
    public override GameObject GameObject { get=>gameObject; }
    public override CharacterController CharacterController { get=>characterController; }
    public override BaseData CurrentStats { get => currentStats; }
}

