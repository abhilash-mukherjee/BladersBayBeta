using System.Collections;
using UnityEngine;

public class AfterDashControlManagerForControllerInput : AfterDashControlManager
{
    //[SerializeField]
    //private VectorVariable pointerHitPos;
    //[SerializeField]
    //[Tooltip("minimum distane between pointerhit direction to Beyblade For Starting Movement After Collision")]
    //private float minSeparation = 0.26f;
    //protected override IEnumerator SwitchControl(DashData data)
    //{
    //    yield return new WaitForSeconds(data.DashControlReductionTime);
    //    CollisionMoverControl.Value = 0f;
    //    DashMoverControl.Value = 0f;
    //    StartCoroutine(EnablePointerMovementWhenPointerDirectionChanges(pointerHitPos.Value));
    //}
    //IEnumerator EnablePointerMovementWhenPointerDirectionChanges(Vector3 _justBeforPointerPos)
    //{
    //    yield return new WaitUntil(() => Vector3.Distance(pointerHitPos.Value, _justBeforPointerPos) >= minSeparation);
    //    OrdinaryMoverControl.Value = 1f;
    //}
}
