using UnityEngine;

[CreateAssetMenu(fileName = "New Virtual Controller Input System", menuName = "Input Systems/ Virtual Controller")]
public class VirtualControllerInputSystem : InputSystem
{
    // Next task is to ensure htat the touchpad animation is in sync with the virtual controller animation
   
    [SerializeField]
    private LayerMask stadiumLayer;
    [SerializeField]
    private float maxDistanceOfRay;
    [SerializeField]
    private VectorVariable VirtualControllerPosition, VirtualControllerUpAxis;
    [SerializeField]
    private float minimumDistanceBetweenHitPointAndBeyBladeToAllowMovement = 0.26f;

    public override void CheckForAbilitySwitchTriggers(InputManager inputManager, GameObject enemyObject)
    {
    }

    public override void ScriptableStart(GameObject gameObject)
    {
    }

    public override Vector3 UpdateInput(InputManager inputManager)
    {
        Vector3 _moveDir;
        Ray virtualRay = new Ray(VirtualControllerPosition.Value, VirtualControllerUpAxis.Value);
        Debug.DrawRay(virtualRay.origin, virtualRay.direction, Color.red, 2f);
        if (Physics.Raycast(virtualRay, out RaycastHit hitInfo, maxDistanceOfRay, stadiumLayer))
        {
            Debug.Log("Ray hit stadium");
            var _tempMoveDirection = hitInfo.point - inputManager.transform.position;
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
            Debug.Log("Ray did not hit stadium");
            _moveDir = Vector3.zero;
        }
        return _moveDir;
    }
}


