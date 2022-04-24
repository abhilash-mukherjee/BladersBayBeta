using System.Collections;
using UnityEngine;
[RequireComponent(typeof(InputManager))]
public class AfterCollisionControlManagerForKeyBoardInput : AfterCollisionControlManager
{
    protected override IEnumerator SwitchControl()
    {
        yield return new WaitForSeconds(ControlCeaseTime);
        CollisionMoverControl.Value = 0f;
        OrdinaryMoverControl.Value = 1f;
    }

}
