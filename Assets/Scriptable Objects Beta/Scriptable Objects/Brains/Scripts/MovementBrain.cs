using UnityEngine;

public abstract class MovementBrain : ScriptableObject
{
    public abstract Vector3 GetMoveDir(GameObject playerObject, GameObject enemyObject,Transform stadiumCentre, Vector3 previousDir);
}
