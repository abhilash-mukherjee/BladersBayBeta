using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDisplayable : UIDisplayable
{
    [SerializeField]
    private Transform positionWhenActive, dissapearForwardTargetPosition, disappearReverseTargetPosition;
    [SerializeField]
    protected List<GameEvent> eventsToRaiseWhenActivated, eventsToRaiseWhenDeactivated;
    [SerializeField]
    private float durationMultiplier;
    [SerializeField]
    private Vector3 localScaleWhenActive;
    private Coroutine animationCoroutine;

    protected Vector3 LocalScaleWhenActive { get => localScaleWhenActive; set => localScaleWhenActive = value; }

    public override void EnterForward()
    {
        transform.position = disappearReverseTargetPosition.position;
        RaiseEvents(eventsToRaiseWhenActivated);
        transform.localScale = localScaleWhenActive;
        Play(positionWhenActive, AnimationType.APPEAR);
    }

    public override void EnterReverse()
    {
        transform.position = dissapearForwardTargetPosition.position;
        RaiseEvents(eventsToRaiseWhenActivated);
        transform.localScale = localScaleWhenActive;
        Play(positionWhenActive, AnimationType.APPEAR);
    }

    public override void ExitForward()
    {
        RaiseEvents(eventsToRaiseWhenDeactivated);
        Play(dissapearForwardTargetPosition, AnimationType.DISAPPEAR);
    }

    public override void ExitReverse()
    {
        RaiseEvents(eventsToRaiseWhenDeactivated);
        Play(disappearReverseTargetPosition, AnimationType.DISAPPEAR);
    }
    protected virtual void Play(Transform _finalTransform, AnimationType animationType)
    {
        if (animationCoroutine != null) StopCoroutine(animationCoroutine);
        float _duration = Vector3.Distance(transform.position, _finalTransform.position) * durationMultiplier;
        animationCoroutine = StartCoroutine(LerpPosition(_finalTransform.position, _duration, animationType));
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration, AnimationType animationType)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        if (animationType == AnimationType.DISAPPEAR) transform.localScale = Vector3.zero;
    }

    protected void RaiseEvents(List<GameEvent> _eventList)
    {
        if (_eventList == null) return;
        foreach (var e in _eventList)
        {
            e.Raise();
        }
    }
    protected enum AnimationType { APPEAR, DISAPPEAR }
}
