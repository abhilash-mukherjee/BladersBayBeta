using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionChecker : MonoBehaviour
{
    public delegate void CollisionHandler(ICollision collision);
    public static event CollisionHandler OnCollided, OnAudioPlayed;
    public void InvokeCollisionEvent(ICollision collision)
    {
        OnCollided?.Invoke(collision);
    }
    public void InvokeAudioEvent(ICollision collision)
    {
        OnAudioPlayed?.Invoke(collision);
    }
}
