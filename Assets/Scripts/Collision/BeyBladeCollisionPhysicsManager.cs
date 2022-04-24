using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeCollisionPhysicsManager : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    private Vector3 m_initialVelocityAfterCollision;

    public Vector3 InitialVelocityAfterCollision { get => m_initialVelocityAfterCollision; }

    private void OnEnable()
    {
        CollisionManager1.OnCollisionPhysicsCalculated += HandleCollsion;
    }

    private void OnDisable()
    {
        CollisionManager1.OnCollisionPhysicsCalculated -= HandleCollsion;

    }

    private void HandleCollsion(IBasicCollision _collision)
    {
        if(_collision.CheckIfPassedGameObjectIsInvolvedInCollision(gameObject))
        {
            m_initialVelocityAfterCollision = _collision.GetVelocityAfterCollision(gameObject);
        }
    }
}
