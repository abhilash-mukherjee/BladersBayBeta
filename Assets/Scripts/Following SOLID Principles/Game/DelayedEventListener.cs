using System.Collections;
using UnityEngine;

public class DelayedEventListener : EventListener
{
    [SerializeField]
    private float delayTime = 0.1f;
    public override void OnEventRaised()
    {
        Debug.Log($"{gameEvent} recieved");
        StartCoroutine(RaiseEventAfterDelay());
    }
    IEnumerator RaiseEventAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        
        base.OnEventRaised();
    }
}