using System.Collections;
using UnityEngine;

public class DashVelocityDecider
{
    //[SerializeField]
    //private MoveVelocityDecidedByDashVelocityDecider decidedVelocity;
    //private float m_dashVelocityMultiplier = 0f;
    //private float m_dashSpeed= 0f;
    //private float m_timeEllapsed = 0f;
    //protected override MovementVelocityVector DecidedVelocity
    //{ get => decidedVelocity; set => decidedVelocity.SetValue(value.Value.x, value.Value.y, value.Value.z); }

    //private void OnEnable()
    //{
    //    DashAbility.OnDashStarted += StartDash;
    //}
    //private void OnDisable()
    //{
    //    DashAbility.OnDashStarted -= StartDash;   
    //}
    //public void StartDash(GameObject obj,DashData data)
    //{
    //    if (obj != gameObject) return;
    //    Debug.Log("dash started");
    //    m_dashSpeed = data.DashSpeed;
    //    m_dashVelocityMultiplier = 1f;
    //    StartCoroutine(ReduceVelocity(data.DashSpeedDecayRate, data.DashTime));
    //}
    //IEnumerator ReduceVelocity(float speedDecayRate, float dashTime)
    //{ 
    //    while(m_timeEllapsed < dashTime)
    //    {
    //        m_timeEllapsed += Time.deltaTime;
    //        m_dashVelocityMultiplier = Mathf.Exp(-speedDecayRate * m_timeEllapsed);
    //        yield return null;
    //    }
    //    m_timeEllapsed = 0f;
    //    m_dashVelocityMultiplier = 0f;
    //    m_dashSpeed = 0f;
    //}
    //protected override Vector3 UpdateVelocity(Vector3 input)
    //{
    //    return input * m_dashVelocityMultiplier * m_dashSpeed;
    //}
}
