using UnityEngine;

public abstract class ResultDecider: MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameEvent playerWonEvent;
    [SerializeField]
    private GameEvent playerLostEvent;

    protected GameObject Player { get => player; }
    protected GameObject Enemy { get => enemy;  }
    protected GameEvent PlayerWonEvent { get => playerWonEvent;  }
    protected GameEvent PlayerLostEvent { get => playerLostEvent; }

    private void OnEnable()
    {
        HealthManager.OnDied += DecideResult;
    }
    private void OnDisable()
    {
        HealthManager.OnDied -= DecideResult;

    }
    protected abstract void DecideResult(GameObject _gameObject);
}