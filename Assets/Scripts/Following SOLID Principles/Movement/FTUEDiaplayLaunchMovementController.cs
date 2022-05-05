using UnityEngine;

public class FTUEDiaplayLaunchMovementController : MovementController
{
    [SerializeField] private CharacterController characterController;
    protected override void Move()
    {
        characterController.SimpleMove(Vector3.zero);
    }
}