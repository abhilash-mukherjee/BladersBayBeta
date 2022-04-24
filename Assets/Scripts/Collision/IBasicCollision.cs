using UnityEngine;

public interface IBasicCollision
{
    ICollidingBeyBlade BeyBlade1 { get; }
    ICollidingBeyBlade BeyBlade2 { get; }

    bool CheckIfPassedGameObjectIsInvolvedInCollision(GameObject _gameObject);
    Vector3 GetVelocityAfterCollision(GameObject _gameObject);
}