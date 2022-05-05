using UnityEngine;

public class StaminaController : AbilityController
{
    [SerializeField]
    private StaminaAbility staminaAbility;
    [SerializeField]
    private AbilityData staminaData;
    [SerializeField]
    private float  initialAvailabilityIndex;
    [SerializeField]
    private GameObject StaminaEffect;
    [SerializeField]
    private FloatVariable HP;
    private void Awake()
    {
        staminaData.AvailabilityIndex = initialAvailabilityIndex;
        staminaData.IsActive = false;
    }
    private void OnEnable()
    {
        CollisionPhysicsProcessor.OnCollisionPhysicsProcessed += ExhaustStaminaAbility;
        StaminaAbility.OnStaminaAbilityActivated += ActivateVFX;
        StaminaAbility.OnStaminaAbilityDeActivated += DeActivateVFX;
        StaminaAbility.OnStaminaAbilityExhausted += DeActivateVFX;
        StaminaAbility.OnStaminaAbilityActivated += SwitchToAbilityStats;
        StaminaAbility.OnStaminaAbilityDeActivated += SwitchToNormalStats;
        StaminaAbility.OnStaminaAbilityExhausted += SwitchToNormalStats;
    }


    private void OnDisable()
    {
        CollisionPhysicsProcessor.OnCollisionPhysicsProcessed -= ExhaustStaminaAbility;
        StaminaAbility.OnStaminaAbilityActivated -= ActivateVFX;
        StaminaAbility.OnStaminaAbilityDeActivated -= DeActivateVFX;
        StaminaAbility.OnStaminaAbilityExhausted -= DeActivateVFX;
        StaminaAbility.OnStaminaAbilityActivated -= SwitchToAbilityStats;
        StaminaAbility.OnStaminaAbilityDeActivated -= SwitchToNormalStats;
        StaminaAbility.OnStaminaAbilityExhausted -= SwitchToNormalStats;
    }
    private void ExhaustStaminaAbility(GameObject _gameObject, Vector3 _finalVelAfterCollision)
    {
        if (_gameObject != gameObject) return;
        staminaAbility.ExhaustAbility(gameObject, staminaData);
    }

    protected override void DeActivateVFX(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        StaminaEffect.SetActive(false);
    }

    protected override void ActivateVFX(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        StaminaEffect.SetActive(true);
    }
    protected override void SwitchToAbilityStats(GameObject gameObject, BaseData staminaStats)
    {
        if (gameObject != this.gameObject) return;
        RaiseAbilityAddedEvent(gameObject, staminaStats, staminaAbility);
    }
    protected override void SwitchToNormalStats(GameObject gameObject, BaseData staminaStats)
    {
        if (gameObject != this.gameObject) return;
        //Debug.Log("Stamina mode off");
        RaiseAbilityRemovedEvent(gameObject, staminaStats, staminaAbility);
    }
    private void Update()
    {
        staminaAbility.IncreaseHealth(HP, staminaData);
    }

}
