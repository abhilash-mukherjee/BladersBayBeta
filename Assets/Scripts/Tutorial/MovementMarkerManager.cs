using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMarkerManager : MonoBehaviour
{
    public delegate void TargetReachedHandler();
    public static event TargetReachedHandler OnTargetReached;
    [SerializeField]
    private Collider thisCollider;
    [SerializeField]
    private string markerReachedSoundName = "MovementMarkerReached";
    private Collider m_playerCollider;
    public void SetCollider(Collider _collider)
    {
        m_playerCollider = _collider;
    }
    private void DestroyMarker()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(m_playerCollider != null)
        {  
            if(CheckCollision())
            {
                OnTargetReached?.Invoke();
                GameAudioManager.Instance.PlaySoundOneShot(markerReachedSoundName);
                DestroyMarker();
            }
        }
    }
    private bool CheckCollision()
    {
        if (thisCollider.bounds.Intersects(m_playerCollider.bounds))
        {
            return true;
        }
        else return false;
    }

    
}
