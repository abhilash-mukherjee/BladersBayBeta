using UnityEngine;

[CreateAssetMenu(fileName ="New AI Stationary Action", menuName ="AI/ Actions / Stand Still")]
public class AIStandStillAction : AIAction
{
    public  override void Act(StateController _enemyStateController, StateController _playerStateController, AIController _AIController)
    {
        _AIController.ChangeMoveDir(Vector3.zero);
    }
}
