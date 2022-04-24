using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New AI Attack Action", menuName ="AI/ Actions / Attack")]
public class AIAttackAction : AIAction
{
    public  override void Act(StateController _enemyStateController, StateController _playerStateController, AIController _AIController)
    {
        _AIController.ChangeMoveDir((_playerStateController.transform.position - _enemyStateController.transform.position).normalized);
    }
}
