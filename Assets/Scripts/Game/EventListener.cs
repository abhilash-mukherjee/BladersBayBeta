using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField]
    private UnityEvent unityEvent;
    [SerializeField]
    private GameEvent gameEvent;
    public void OnEventRaised()
    {
        unityEvent?.Invoke();
    }
    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }
}
