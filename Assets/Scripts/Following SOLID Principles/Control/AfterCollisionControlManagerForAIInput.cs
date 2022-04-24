using System.Collections;
using UnityEngine;

public class AfterCollisionControlManagerForAIInput : AfterCollisionControlManager
{
    protected override IEnumerator SwitchControl()
    {
        yield return new WaitForSeconds(ControlCeaseTime);
        CollisionMoverControl.Value = 0f;
        OrdinaryMoverControl.Value = 1f;
    }

}