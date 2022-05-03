using System.Collections;
using UnityEngine;
public class DefenceController : AbilityController
{
    [SerializeField]
    private DefenceAbility defenceAbility;
    [SerializeField]
    private AbilityData defenceStats;
    [SerializeField]
    private float initialAvailabilityIndex;
    [SerializeField]
    private GameObject DefenceEffect;
    [SerializeField]
    private float defenceShieldDissolveTimeGap = 0.5f;
    private void Awake()
    {
        defenceStats.AvailabilityIndex = initialAvailabilityIndex;
        defenceStats.IsActive = false;
    }
    private void OnEnable()
    {
        DefenceAbility.OnDefenceAbilityActivated += ActivateVFX;
        DefenceAbility.OnDefenceAbilityDeActivated += DeActivateVFX;
        DefenceAbility.OnDefenceAbilityExhausted += DeActivateVFX;
        DefenceAbility.OnDefenceAbilityActivated += SwitchToAbilityStats;
        DefenceAbility.OnDefenceAbilityDeActivated += SwitchToNormalStats;
        DefenceAbility.OnDefenceAbilityExhausted += SwitchToNormalStats;
        CollisionPhysicsProcessor.OnCollisionPhysicsProcessed += ExhaustDefenceAbility;
    }


    private void OnDisable()
    {
        DefenceAbility.OnDefenceAbilityActivated -= ActivateVFX;
        DefenceAbility.OnDefenceAbilityDeActivated -= DeActivateVFX;
        DefenceAbility.OnDefenceAbilityExhausted -= DeActivateVFX;
        DefenceAbility.OnDefenceAbilityActivated -= SwitchToAbilityStats;
        DefenceAbility.OnDefenceAbilityDeActivated -= SwitchToNormalStats;
        DefenceAbility.OnDefenceAbilityExhausted -= SwitchToNormalStats;
        CollisionPhysicsProcessor.OnCollisionPhysicsProcessed -= ExhaustDefenceAbility;
    }

    protected override void DeActivateVFX(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        DefenceEffect.SetActive(false);
    }

    protected override void ActivateVFX(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        DefenceEffect.SetActive(true);
    }
    protected override void SwitchToAbilityStats(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        Debug.Log($"Defence mode on of {gameObject}");
        RaiseAbilityAddedEvent(gameObject, attackStats, defenceAbility);
    }
    protected override void SwitchToNormalStats(GameObject gameObject, BaseData attackStats)
    {
        if (gameObject != this.gameObject) return;
        RaiseAbilityRemovedEvent(gameObject, attackStats, defenceAbility);
    }
    private void ExhaustDefenceAbility(GameObject _gameObject, Vector3 _finalVelAfterCollision)
    {
        if (_gameObject != gameObject) return;
        if (!defenceStats.IsActive) return;
        StartCoroutine(DissolveDefenceShield());
    }
    
    IEnumerator DissolveDefenceShield()
    {
        yield return new WaitForSeconds(defenceShieldDissolveTimeGap);
        defenceAbility.ExhaustAbility(gameObject, defenceStats);
    }
}
