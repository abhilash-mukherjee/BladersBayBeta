using UnityEngine;

[CreateAssetMenu(fileName ="New Dash Ability", menuName ="Ability System/Abilities/ Dash Ability")]
public class DashAbility 
{
    //public delegate void DashStartHandler(GameObject obj, DashData dashData);
  
    //public static event DashStartHandler OnDashStarted;
    //[SerializeField]
    //private DashData dashData;
    //private float m_currentAvailabilityIndex;
    //private bool m_isAbilityReady, m_isAbilityActive;
    //public bool IsAbilityActive { get => m_isAbilityActive; set => m_isAbilityActive = value; }

    //private float CurrentAvailabilityIndex 
    //{ 
    //    get => m_currentAvailabilityIndex;
    //    set
    //    {
    //        m_currentAvailabilityIndex = value > 1 ? 1 : (value < 0f ? 0f : value);
    //        m_isAbilityReady = m_currentAvailabilityIndex == 1;
    //    }
    //}

    //public override bool IsActive { get => m_isAbilityActive; }

    //public override void ActivateAbility(GameObject beyBlade)
    //{
    //    m_isAbilityActive = true;
    //    m_isAbilityReady = false;
    //    OnDashStarted.Invoke(beyBlade,dashData);
    //    ExhaustAbility(beyBlade);
    //}

    //public override void Behave(GameObject beyBlade)
    //{
    //    if (!m_isAbilityActive) return;
    //}

    //public override void DegradeAbility(float _amt, GameObject beyBlade)
    //{
    //    CurrentAvailabilityIndex -= _amt;
    //}

    //public override void ExhaustAbility(GameObject beyBlade)
    //{
    //    CurrentAvailabilityIndex = 0f;
    //    m_isAbilityReady = false;
    //    m_isAbilityActive = false;
    //}

    //public override void MakeAbilityReady(GameObject beyBlade)
    //{
    //    CurrentAvailabilityIndex = 1f;
    //    m_isAbilityReady = true;
    //}

    //public override void ReplenishAbility(float _amt, GameObject beyBlade)
    //{
    //    CurrentAvailabilityIndex += _amt;
    //}

    //public override void UpdateAbility(GameObject beyBlade)
    //{
    //    ReplenishAbility(dashData.DashRechargeRate * Time.deltaTime, beyBlade);
    //}

    //public override void SetInitialAvailabilityIndex(float value)
    //{
    //    CurrentAvailabilityIndex = value;
    //}
}
