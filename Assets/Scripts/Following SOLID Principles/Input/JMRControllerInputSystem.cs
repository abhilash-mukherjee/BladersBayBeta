using JMRSDK.InputModule;
using UnityEngine;
[CreateAssetMenu(fileName = "New Controller Input System", menuName = "Input Systems/ JMR Controller")]
public class JMRControllerInputSystem : InputSystem
{
    [SerializeField]
    private VectorVariable controllerHitPoint;
    [SerializeField]
    LayerMask stadiumLayer;
    [SerializeField]
    private float maxDistanceOfRay = 100f;
    [SerializeField]
    private float minimumDistanceBetweenHitPointAndBeyBladeToAllowMovement = 0.26f;
    [SerializeField]
    private InputTrigger actionTriggeredByUpSwipe, actionTriggeredByLeftSwipe, actionTriggeredByRightSwipe;
    [SerializeField]
    private GameEvent UpSwipeEvent, LeftSwipeEvent, RightSwipeEvent;

    public override void CheckForAbilitySwitchTriggers(InputManager inputManager, GameObject enemyObject)
    {
        bool isSwipeLeft = JMRInteraction.GetSwipeLeft(out float valL);
        bool isSwipeRight = JMRInteraction.GetSwipeRight(out float valR);
        bool isSwipeUp = JMRInteraction.GetSwipeUp(out float valU);
        if (isSwipeRight)
        {
            RaiseActionTriggerEvent(inputManager.gameObject, actionTriggeredByRightSwipe);
            RightSwipeEvent.Raise();
            Debug.Log("Right Swiped");
        }
        if (isSwipeLeft)
        {
            RaiseActionTriggerEvent(inputManager.gameObject, actionTriggeredByLeftSwipe);
            LeftSwipeEvent.Raise();
        }
        if (isSwipeUp)
        {
            RaiseActionTriggerEvent(inputManager.gameObject, actionTriggeredByUpSwipe);
            UpSwipeEvent.Raise();
        }
    }

    public override void ScriptableStart(GameObject gameObject)
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
    public override Vector3 UpdateInput(InputManager inputManager)
    {
        return GiveMovementDirection(inputManager);
    }

    private  Vector3 GiveMovementDirection(InputManager inputManager)
    {
        Vector3 _moveDir;
        Ray pointerRay = JMRPointerManager.Instance.GetCurrentRay();
        if (Physics.Raycast(pointerRay, out RaycastHit hit, maxDistanceOfRay, stadiumLayer))
        {
            var pt = hit.point;
            controllerHitPoint.SetValue(pt.x, pt.y,pt.z);
            var _tempMoveDirection = hit.point - inputManager.transform.position;
            if (_tempMoveDirection.magnitude < minimumDistanceBetweenHitPointAndBeyBladeToAllowMovement)
            {
                _moveDir = Vector3.zero;
                return _moveDir;
            }
            _moveDir = new Vector3(_tempMoveDirection.x, 0, _tempMoveDirection.z);
            _moveDir.Normalize();
        }
        else
        {
            var pt = Vector3.positiveInfinity;
            controllerHitPoint.SetValue(pt.x, pt.y, pt.z);
            _moveDir = Vector3.zero;
        }
        return _moveDir;
    }

}


