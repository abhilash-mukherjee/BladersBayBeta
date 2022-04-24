using System.Collections;
using UnityEngine;

public class PlayerCollisionMovementSwitchManager: CollisionMovementSwitchManager
{
    protected override void HandleCollision()
    {
        collisionMovementManager.enabled = true;
        ordinaryMovementManager.enabled = false;
        StartCoroutine(EndCollsion(movementControlSwitchTime));
    }
    IEnumerator EndCollsion(float _endTime)
    {
        yield return new WaitForSeconds(_endTime);
        collisionMovementManager.enabled = false;
        Vector3 _stadiumHitPointWhileExitingCollisionPhase = inputController.StadiumHitPoint;
        StartCoroutine(EnablePointerMovementWhenPointerDirectionChanges(_stadiumHitPointWhileExitingCollisionPhase));
    }

    IEnumerator EnablePointerMovementWhenPointerDirectionChanges(Vector3 _hitPoint)
    {
        yield return new WaitUntil(() => inputController.StadiumHitPoint != _hitPoint);
        ordinaryMovementManager.enabled = true;
    }

}
