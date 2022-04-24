using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class BeyBladeCollisionType: ScriptableObject
{
    [SerializeField]
    private string collisionTag;
    [SerializeField]
    protected float m_collisionIndex;
    [SerializeField]
    protected float minAngleDiffernce;
    [SerializeField]
    protected float maxAngleDiffernce;
    public float CollisionIndex { get => m_collisionIndex; }
    public string CollisionTag { get => collisionTag;  }

    public virtual bool CheckCondition(BeyBladeCollision _collision)
    {
        if(_collision.AngleDifference <= maxAngleDiffernce && _collision.AngleDifference > minAngleDiffernce)
        {
            return true;
        }
        return false;
    }
    public abstract List<ICollidingBeyBlade> GetAttacker(BeyBladeCollision _collision);
    public abstract List<ICollidingBeyBlade> GetVictim(BeyBladeCollision _collision);
}
