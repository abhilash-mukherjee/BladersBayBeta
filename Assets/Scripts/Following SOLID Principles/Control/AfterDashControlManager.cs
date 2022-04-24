using System.Collections;
using UnityEngine;

public abstract class AfterDashControlManager : MonoBehaviour
{
    //[SerializeField]
    //private OrdinaryVelocityDeciderControl ordinaryMoverControl;
    //[SerializeField]
    //private CollisionVelocityDecierControl collisionMoverControl;
    //[SerializeField]
    //private DashVelocityDeciderControl dashMoverControl;
    //[SerializeField]
    //private 
    //protected OrdinaryVelocityDeciderControl OrdinaryMoverControl { get => ordinaryMoverControl; set => ordinaryMoverControl = value; }
    //protected CollisionVelocityDecierControl CollisionMoverControl { get => collisionMoverControl; set => collisionMoverControl = value; }
    //protected DashVelocityDeciderControl DashMoverControl { get => dashMoverControl; set => dashMoverControl = value; }

    //private void Awake()
    //{
    //    OrdinaryMoverControl.Value = 1f;
    //    CollisionMoverControl.Value = 0f;
    //    DashMoverControl.Value = 0f;
    //}
    //private void OnEnable()
    //{
    //    DashAbility.OnDashStarted += ChangeControl;
    //}
    //private void OnDisable()
    //{
    //    DashAbility.OnDashStarted -= ChangeControl;
    //}
    //private void ChangeControl(GameObject obj,DashData data)
    //{
    //    if (obj != gameObject) return;
    //    OrdinaryMoverControl.Value = 0f;
    //    CollisionMoverControl.Value = 0f;
    //    DashMoverControl.Value = data.DashMaxControl;
    //    StartCoroutine(SwitchControl(data));
    //}
    //protected abstract IEnumerator SwitchControl(DashData data);

}
