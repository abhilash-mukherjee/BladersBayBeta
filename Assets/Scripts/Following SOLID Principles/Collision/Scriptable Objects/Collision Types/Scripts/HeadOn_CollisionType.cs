using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Head On Collision Type", menuName = "Collision Types/ Head On")]
public class HeadOn_CollisionType : CollisionType
{
    [SerializeField]
    private float collisionIndex;
    [SerializeField][Tooltip("Min inclusive")]
    private float minAngleDiff;
    [SerializeField]
    [Tooltip("Max exclusive")]
    private float maxAngleDiff;
    public override float CollisionIndex { get => collisionIndex; }

    protected override float MinAngleDifference { get => minAngleDiff; }
    protected override float MaxAngleDifference { get => maxAngleDiff;}

    public override bool CheckCondition(ICollision _collision)
    {
        if (_collision.CollisionAngle < maxAngleDiff && _collision.CollisionAngle >= minAngleDiff)
        {
            Debug.Log($"Collision index = {collisionIndex}, andgle = {_collision.CollisionAngle}");
            return true;
        }
        {
            Debug.Log($"Angle = {_collision.CollisionAngle}");
            return false;
        }
    }

    public override List<Collidable> GetAttackers(ICollision collision)
    {
        var _AttackerList = new List<Collidable>();
        _AttackerList.Add(collision.Collidable1);
        _AttackerList.Add(collision.Collidable2);
        Debug.Log($"Attacker's List length = {_AttackerList.Count} and Elements = {_AttackerList[0]} , {_AttackerList[1]}");
        return _AttackerList;
    }

    public override List<Collidable> GetVictims(ICollision collision)
    {
        var _victimList = new List<Collidable>();
        _victimList.Add(collision.Collidable1);
        _victimList.Add(collision.Collidable2);
        Debug.Log($"Victim's List length = {_victimList.Count} and Elements = {_victimList[0]} , {_victimList[1]}");
        return _victimList;
    }
}
