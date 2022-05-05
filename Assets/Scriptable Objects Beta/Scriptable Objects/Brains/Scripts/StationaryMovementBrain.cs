using UnityEngine;

[CreateAssetMenu(fileName = "New Stationary Movement Brain ", menuName = "AI Brains / Movement Brain / Stationary")]
public class StationaryMovementBrain : MovementBrain
{
    public override Vector3 GetMoveDir(GameObject playerObject, GameObject enemyObject, Transform stadiumCentre, Vector3 previousDir)
    {
        return Vector3.zero;
    }
}