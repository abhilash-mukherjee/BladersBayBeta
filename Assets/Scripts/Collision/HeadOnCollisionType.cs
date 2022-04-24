using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New HeadOn Collision", menuName = "BeyBlade Collision/HeadOn Collision")]
public class HeadOnCollisionType : BeyBladeCollisionType
{
    [SerializeField]
    private float maximumAngleForHeadOnCollision;
    public override bool CheckCondition(BeyBladeCollision _collision)
    {

        if (_collision.AngleDifference <= maximumAngleForHeadOnCollision && _collision.AngleDifference <= maxAngleDiffernce && _collision.AngleDifference > minAngleDiffernce)
        {
            Debug.Log($"Angle diff = {_collision.AngleDifference}");
            return true;
        }
        else return false;
    }
    public override List<ICollidingBeyBlade> GetAttacker(BeyBladeCollision _collision)
    {
        var _AttackerList = new List<ICollidingBeyBlade>();
        _AttackerList.Add(_collision.BeyBlade1);
        _AttackerList.Add(_collision.BeyBlade2);
        Debug.Log($"Attacker's List length = {_AttackerList.Count} and Elements = {_AttackerList[0]} , {_AttackerList[1]}");
        return _AttackerList;
    }

    public override List<ICollidingBeyBlade> GetVictim(BeyBladeCollision _collision)
    {
        var _victimList = new List<ICollidingBeyBlade>();
        _victimList.Add(_collision.BeyBlade1);
        _victimList.Add(_collision.BeyBlade2);
        return _victimList;
    }
}
