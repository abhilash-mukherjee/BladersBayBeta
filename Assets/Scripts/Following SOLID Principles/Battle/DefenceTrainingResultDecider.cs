using UnityEngine;
using System.Collections;

public class DefenceTrainingResultDecider : ResultDecider
{
    [SerializeField]
    private float resultDeclareEventRaiseTimeDelay = 3f;
    [SerializeField] private GameEvent instantEventToRaiseAfterFinish;
    [SerializeField]
    private int minimumNumberOfCollisions = 10;
    private int m_collisionCount = 0;
    private void OnEnable()
    {
        m_collisionCount = 0;
    }
    private void OnDisable()
    {
        m_collisionCount = 0;
    }
    protected override void DecideResult(GameObject _gameObject)
    {
        if (_gameObject == Player)
        {
            instantEventToRaiseAfterFinish.Raise();
            StartCoroutine(RaiseEventAfterDelay(PlayerLostEvent));
            m_collisionCount = 0;
            return;
        }
        if (_gameObject == Enemy)
        {
            instantEventToRaiseAfterFinish.Raise();
            StartCoroutine(RaiseEventAfterDelay(PlayerWonEvent));
            m_collisionCount = 0;
        }
    }

    public void AddToCollisionCount()
    {
        m_collisionCount++;
        if (m_collisionCount >= minimumNumberOfCollisions) DecideResult(Player);
    }

    IEnumerator RaiseEventAfterDelay(GameEvent _event)
    {
        yield return new WaitForSeconds(resultDeclareEventRaiseTimeDelay);
        _event.Raise();
        Debug.Log($"{_event.name} raised Won");
    }
}