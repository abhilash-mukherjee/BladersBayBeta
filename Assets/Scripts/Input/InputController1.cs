using UnityEngine;
using UnityEngine.Events;
public abstract class InputController1: MonoBehaviour
{
    public delegate void SwipeHandler(InputGestures.SwipeMode _mode, GameObject _gameObject);
    public static event SwipeHandler OnSwiped1;
    protected Vector3 m_moveDirection;
    [HideInInspector]
    public Vector3 MoveDirection
    {
        get { return m_moveDirection; }
    }
    protected Vector3 m_stadiumHitPoint;
    [HideInInspector]
    public Vector3 StadiumHitPoint { get => m_stadiumHitPoint; }
    public virtual Vector3 GiveMovementDirection()
    {
        m_stadiumHitPoint = Vector3.negativeInfinity;
        return Vector3.zero; 
    }

    public virtual void StopStartMovementAlternatively() { }
    public virtual void GoToDefenceMode() { }

    public virtual void GoToAttackMode() { }
    public virtual void GoToBalanceMode() { }
    protected virtual void SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode _mode, GameObject _gameObject)
    {
        OnSwiped1?.Invoke(_mode, gameObject);
    }
}
