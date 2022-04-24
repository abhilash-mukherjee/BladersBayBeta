
using UnityEngine;

public class OrdinaryMovementManagerWithCharacterController : MovementManagerWithCharacterController
{
    [SerializeField]
    private StateController stateController;
    protected override void Awake()
    {
        base.Awake();
        m_type = this.GetType();
    }
    protected override Vector3 CalculateMovement()
    {
         return stateController.CurrentState.Data.Speed * m_inputController.MoveDirection;
    }
}
