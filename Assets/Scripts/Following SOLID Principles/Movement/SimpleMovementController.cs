using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementController : MovementController
{
    [SerializeField]
    private List<VelocityDeciderAndControlMapping> VelocityControlMappings;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private VectorVariable finalVelocityVector;
    protected override void Move()
    {
        var _vec = Vector3.zero;
        float totContrl = 0f;
        for (int i = 0; i < VelocityControlMappings.Count; i++)
        { 
            _vec += VelocityControlMappings[i].VelocityDecider.Velocity * VelocityControlMappings[i].Control.Value;
            totContrl += VelocityControlMappings[i].Control.Value;
        }
        _vec = totContrl > 0f ? _vec * (1f / totContrl) : Vector3.zero ;
        finalVelocityVector.SetValue(_vec.x,_vec.y,_vec.z);
        characterController.SimpleMove(_vec);
    }
}

[System.Serializable]
public class VelocityDeciderAndControlMapping
{
    public VelocityDecider VelocityDecider;
    public Control Control;
}