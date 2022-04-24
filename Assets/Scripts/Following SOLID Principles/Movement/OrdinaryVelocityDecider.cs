using System.Collections;
using UnityEngine;

public class OrdinaryVelocityDecider : VelocityDecider
{
    [SerializeField]
    private MoveVelocityDecidedByOrdinaryVelocityDecider decidedVelocity;
    [SerializeField]
    private BaseData currentStats;

    protected override MovementVelocityVector DecidedVelocity { get => decidedVelocity; set => decidedVelocity.SetValue( value.Value.x, value.Value.y, value.Value.z); }

    protected override Vector3 UpdateVelocity(Vector3 input)
    {
        return input * currentStats.Speed;
    }
}
