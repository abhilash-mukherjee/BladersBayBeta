using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController1))]
public abstract class MovementManagerWithCharacterController : MonoBehaviour
{
    protected CharacterController m_characterController;
    protected BeyBladeParameters m_BeyBladeParameters;
    protected InputController1 m_inputController;
    private Vector3 m_currentVelocity;
    protected Type m_type;
    public Vector3 CurrentVelocity { get => m_currentVelocity; }
    public Type Type { get => m_type; }

    protected virtual void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
        m_BeyBladeParameters = GetComponent<BeyBladeParameters>();
        m_inputController = GetComponent<InputController1>();
    }

    private void Update()
    {
        m_currentVelocity = CalculateMovement();
        m_characterController.SimpleMove(m_currentVelocity);
    }

    protected virtual Vector3 CalculateMovement()
    {
        return Vector3.zero;
    }
}
