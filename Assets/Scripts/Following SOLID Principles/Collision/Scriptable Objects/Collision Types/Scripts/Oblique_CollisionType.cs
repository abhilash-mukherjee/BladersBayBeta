using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Oblique Collision Type", menuName = "Collision Types/ Oblique")]
public class Oblique_CollisionType : CollisionType
{
    [SerializeField]
    private float collisionIndex;
    [SerializeField]
    private float minAngleDiff, maxAngleDiff;
    public override float CollisionIndex { get => collisionIndex; }

    protected override float MinAngleDifference { get => minAngleDiff; }
    protected override float MaxAngleDifference { get => maxAngleDiff;}

    public override bool CheckCondition(ICollision _collision)
    {
        if (_collision.CollisionAngle <= maxAngleDiff && _collision.CollisionAngle > minAngleDiff)
        {
            Debug.Log($"Collision index = {collisionIndex}");
            return true;
        }
        return false;
    }

    public override List<Collidable> GetAttackers(ICollision _collision)
    {
        var _attackerList = new List<Collidable>();
        if (_collision.AngleOfCollision1 > _collision.AngleOfCollision2)
            _attackerList.Add(_collision.Collidable2);
        else _attackerList.Add(_collision.Collidable1);
        return _attackerList;
    }

    public override List<Collidable> GetVictims(ICollision _collision)
    {
        var _victimList = new List<Collidable>();
        if (_collision.AngleOfCollision1 > _collision.AngleOfCollision2)
            _victimList.Add(_collision.Collidable1);
        else _victimList.Add(_collision.Collidable2);
        return _victimList;
    }
}