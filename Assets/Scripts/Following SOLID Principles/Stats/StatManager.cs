using UnityEngine;

public abstract class StatManager: MonoBehaviour
{
    [SerializeField]
    private BaseData currentStats, balanceStats;

    protected BaseData m_CurrentStats { get => currentStats; set => currentStats = value; }
    public BaseData CurrentStats { get => currentStats; set => currentStats = value; }
    protected BaseData m_BalanceStats { get => balanceStats; set => balanceStats = value; }
    protected AbilityStatMapping CurrentAbilityStatMapping { get => currentAbilityStatMapping; set => currentAbilityStatMapping = value; }

    private AbilityStatMapping currentAbilityStatMapping;
    private void OnEnable()
    {
        AbilityController.OnAbilityAdded += OnStatAdded;
        AbilityController.OnAbilityRemoved += OnStatRemoved;
    }

    private void OnDisable()
    {
        AbilityController.OnAbilityAdded -= OnStatAdded;
        AbilityController.OnAbilityRemoved -= OnStatRemoved;
    }

    private void Awake()
    {
        currentStats.SetValues(balanceStats);
    }
    protected abstract void OnStatAdded(GameObject _gameObject, BaseData newStat, Ability newAbility);
    protected abstract void OnStatRemoved(GameObject _gameObject, BaseData oldStat, Ability oldAbility);
}