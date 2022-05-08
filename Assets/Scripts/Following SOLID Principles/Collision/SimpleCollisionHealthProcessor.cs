using System.Collections.Generic;
using UnityEngine;

public class SimpleCollisionHealthProcessor : CollisionHealthProcessor
{
    
    [SerializeField]
    private List<CollisionType> collisionTypes;
    protected override void ProcessHealth(ICollision collision)
    {
        List<Collidable> victims = new List<Collidable>();
        List<Collidable> attackers = new List<Collidable>();
        var type = GetCollisionType(collision);
        if(type == null)
        {
            Debug.LogError("This collision did not have a valid type");
            return;
        }
        Debug.Log($"Inside Collision Helth process or of {gameObject.name} Collision index = " + type.CollisionIndex);
        victims = type.GetVictims(collision);
        attackers = type.GetAttackers(collision);
        foreach(var v in victims)
        {
            RaiseGameObjectVictimEvent(v.GameObject, type.CollisionIndex, attackers.Find(p=>p.GameObject != v.GameObject).CurrentStats.AttackValue);
        }
        foreach(var a in attackers)
        {
            RaiseGameObjectAttckerEvent(a.GameObject, type.CollisionIndex); 
        }
    }
    private CollisionType GetCollisionType(ICollision collision)
    {
        foreach (var _category in collisionTypes)
        {
            if (_category.CheckCondition(collision))
                return _category;
        }
        return null;
    }
}
