using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionType : ScriptableObject
{
    public abstract float CollisionIndex { get;  }
    protected abstract float MinAngleDifference { get ; }
    protected abstract float MaxAngleDifference { get ;}

    public abstract bool CheckCondition(ICollision _collision);
    public abstract List<Collidable> GetAttackers(ICollision collision);
    public abstract List<Collidable> GetVictims(ICollision collision);
}
