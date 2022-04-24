using System.Collections;
using UnityEngine;
[RequireComponent(typeof(InputManager))]
public abstract class VelocityDecider : MonoBehaviour
{
    [SerializeField]
    private InputVector movementInput;
    protected abstract MovementVelocityVector DecidedVelocity { get; set; }
    public Vector3 Velocity { get=>DecidedVelocity.Value; }
    private void Update()
    {
        var vel = UpdateVelocity(movementInput.Value);
        SetDecidedVelocity(vel);
    }
    protected abstract Vector3 UpdateVelocity(Vector3 _input);
    protected void SetDecidedVelocity(Vector3 vel)
    {
        DecidedVelocity.SetValue(vel.x, vel.y, vel.z);
    }

}
