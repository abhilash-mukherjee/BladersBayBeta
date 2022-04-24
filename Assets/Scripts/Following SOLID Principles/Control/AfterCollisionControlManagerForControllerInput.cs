using System.Collections;
using UnityEngine;
public class AfterCollisionControlManagerForControllerInput : AfterCollisionControlManager
{
    [SerializeField]
    private VectorVariable pointerHitPos;
    [SerializeField]
    [Tooltip("minimum distane between pointerhit direction to Beyblade For Starting Movement After Collision")]
    private float minSeparation = 0.26f;
    protected float MinSeparation { get => minSeparation; }
    protected override IEnumerator SwitchControl()
    {
        yield return new WaitForSeconds(ControlCeaseTime);
        CollisionMoverControl.Value = 0f;
        StartCoroutine(EnablePointerMovementWhenPointerDirectionChanges(pointerHitPos.Value));
    }

    IEnumerator EnablePointerMovementWhenPointerDirectionChanges(Vector3 _justBeforPointerPos)
    {
        yield return new WaitUntil(() => Vector3.Distance(pointerHitPos.Value , _justBeforPointerPos) >= MinSeparation);
        OrdinaryMoverControl.Value = 1f;
    }
}
