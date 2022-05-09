using UnityEngine;
using System.Collections;

public class StaminaTrainingResultDecider : ResultDecider
{
    [SerializeField]
    private float resultDeclareEventRaiseTimeDelay = 3f;
    [SerializeField] private GameEvent instantEventToRaiseAfterFinish;
    [SerializeField]
    private FloatVariable PlayerStainaTrainingHP;
    private bool m_shouldCheck = false, m_isEventRaised = false;
    public void StartChecckingForPlayerHealthMaximization()
    {
        m_shouldCheck = true;
        m_isEventRaised = false;
    }
    public void StopChecckingForPlayerHealthMaximization()
    {
        m_shouldCheck = false;
    }
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
    private void Update()
    {
        if (!m_shouldCheck) return;
        if(PlayerStainaTrainingHP.Value >= 98f)
        {
            if (m_isEventRaised) return;
            DecideResult(Enemy);
            m_isEventRaised = true;
        }
        
    }

    IEnumerator RaiseEventAfterDelay(GameEvent _event)
    {
        yield return new WaitForSeconds(resultDeclareEventRaiseTimeDelay);
        _event.Raise();
    }
}
