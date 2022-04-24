using UnityEngine;

public class AttackController : AbilityController
{
    [SerializeField]
    private AttackAbility attackAbility;
    [SerializeField]
    private AbilityData attackStats;
    [SerializeField]
    private float thresholdCollisionIndex, collisionMultiplierAtZeroCollisionIndex, initialAvailabilityIndex;
    [SerializeField]
    private GameObject AttackEffect;
    private void Awake()
    {
        attackStats.AvailabilityIndex = initialAvailabilityIndex;
        attackStats.IsActive = false;
    }
    private void OnEnable()
    {
        //CollisionHealthResponder.OnObjectIsAttacker += ReplenishAbility;
        AttackAbility.OnAtackAbilityActivated += ActivateVFX;
        AttackAbility.OnAttackAbilityDeActivated += DeActivateVFX;
        AttackAbility.OnAttackAbilityExhausted += DeActivateVFX;
        AttackAbility.OnAtackAbilityActivated += SwitchToAbilityStats;
        AttackAbility.OnAttackAbilityDeActivated += SwitchToNormalStats;
        AttackAbility.OnAttackAbilityExhausted += SwitchToNormalStats;
    }


    private void OnDisable()
    {
        //CollisionHealthResponder.OnObjectIsAttacker -= ReplenishAbility;
        AttackAbility.OnAtackAbilityActivated -= ActivateVFX;
        AttackAbility.OnAttackAbilityDeActivated -= DeActivateVFX;
        AttackAbility.OnAttackAbilityExhausted -= DeActivateVFX;
        AttackAbility.OnAtackAbilityActivated -= SwitchToAbilityStats;
        AttackAbility.OnAttackAbilityDeActivated -= SwitchToNormalStats;
        AttackAbility.OnAttackAbilityExhausted -= SwitchToNormalStats;
    }

    protected override void DeActivateVFX(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        AttackEffect.SetActive(false);
    }

    protected override void ActivateVFX(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        AttackEffect.SetActive(true);
    }
    protected override void SwitchToAbilityStats(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        Debug.Log($"Attack mode on of {gameObject}");
        RaiseAbilityAddedEvent(gameObject, attackStats, attackAbility);
    }
    protected override void SwitchToNormalStats(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        // Debug.Log("Attack mode off");
        RaiseAbilityRemovedEvent(gameObject, attackStats, attackAbility);
    }

    //protected void ReplenishAbility(GameObject _gameObject, float _collisionIndex)
    //{
    //    if (_gameObject != this.gameObject)
    //    {
    //        return;
    //    }
    //    if (attackStats.IsActive)
    //    {
    //        Debug.Log("Attack was already active");
    //        return;
    //    }
    //    var c = collisionMultiplierAtZeroCollisionIndex;
    //    var x = _collisionIndex;
    //    var t = thresholdCollisionIndex;
    //    float collisionMultiplier = _collisionIndex > thresholdCollisionIndex ? 1: ((1- c) / t) * x + c;
    //    var value = attackStats.AbilityReplenishmentRate * collisionMultiplier;
    //    Debug.Log("Replenishment = " + value);
    //    attackAbility.ReplenishAbility(value, gameObject,attackStats );
    //}

}
