using UnityEngine;
using System.Collections;

public class TrainingResultDecider : ResultDecider
{
    [SerializeField]
    private float resultDeclareEventRaiseTimeDelay = 3f;
    [SerializeField] private GameEvent instantEventToRaiseAfterFinish;
    protected override void DecideResult(GameObject _gameObject)
    {
        if (_gameObject == Player)
        {
            instantEventToRaiseAfterFinish.Raise();
            StartCoroutine(RaiseEventAfterDelay(PlayerLostEvent));
            return;
        }
        if (_gameObject == Enemy)
        {
            instantEventToRaiseAfterFinish.Raise();
            StartCoroutine(RaiseEventAfterDelay(PlayerWonEvent));
        }
    }

    IEnumerator RaiseEventAfterDelay(GameEvent _event)
    {
        yield return new WaitForSeconds(resultDeclareEventRaiseTimeDelay);
        _event.Raise();
    }
}
