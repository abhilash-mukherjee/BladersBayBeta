using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionMovementSwitchManager : MonoBehaviour
{
    [SerializeField]
    protected OrdinaryMovementManagerWithCharacterController ordinaryMovementManager;
    [SerializeField]
    protected CollisionMovementManagerWithCharacterController collisionMovementManager;
    [SerializeField]
    protected InputController1 inputController;
    [SerializeField]
    protected float movementControlSwitchTime = 0.99f;
    private MovementManagerWithCharacterController activeMovementController;

    public MovementManagerWithCharacterController ActiveMovementController { get => activeMovementController;}

    private void OnEnable()
    {
        CollisionManager1.OnCollisionStarted += CollisionStarted;
        collisionMovementManager.enabled = false;
    }
    protected virtual void HandleCollision() { }
    private void OnDisable()
    {
        CollisionManager1.OnCollisionStarted -= CollisionStarted;
    }
    private void CollisionStarted(IBasicCollision _collision)
    {
        if (_collision.CheckIfPassedGameObjectIsInvolvedInCollision(gameObject))
        {
            HandleCollision();
        }
    }
}
 