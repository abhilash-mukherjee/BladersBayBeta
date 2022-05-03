using System.Collections.Generic;
using UnityEngine;

public class ThreeDDisplayable : UIDisplayable
{
    [SerializeField]
    private string APPEAR_FORWARD_TRIGGER, APPEAR_REVERSE_TRIGGER, DISAPPEAR_FORWARD_TRIGGER, DISAPPEAR_REVERSE_TRIGGER;
    [SerializeField]
    private Animator controllerAnimator;
    [SerializeField]
    private GameObject animatingChild;
    [SerializeField]
    private List<GameEvent> eventsToRaiseWhenActivated, eventsToRaiseWhenDeactivated;
    public override void EnterForward()
    {
        RaiseEvents(eventsToRaiseWhenActivated);
        animatingChild.SetActive(true);
        controllerAnimator.SetTrigger(APPEAR_FORWARD_TRIGGER);
    }

    public override void EnterReverse()
    {
        RaiseEvents(eventsToRaiseWhenActivated);
        animatingChild.SetActive(true);
        controllerAnimator.SetTrigger(APPEAR_REVERSE_TRIGGER);
    }

    public override void ExitForward()
    {
        RaiseEvents(eventsToRaiseWhenDeactivated);
        controllerAnimator.SetTrigger(DISAPPEAR_FORWARD_TRIGGER);
        animatingChild.SetActive(false);
    }

    public override void ExitReverse()
    {
        RaiseEvents(eventsToRaiseWhenDeactivated);
        controllerAnimator.SetTrigger(DISAPPEAR_REVERSE_TRIGGER);
        animatingChild.SetActive(false);
    }
    private void RaiseEvents(List<GameEvent> _eventList)
    {
        if (_eventList == null) return;
        foreach (var e in _eventList)
        {
            e.Raise();
        }
    }
}
