using UnityEngine;
using JMRSDK.InputModule;

public class TutorialInputController : InputController1, IFn1Handler, ISwipeHandler
{
    [SerializeField]
    LayerMask stadiumLayer;
    [SerializeField]
    private float maxDistanceOfRay = 100f;
    [SerializeField]
    private VirtualControllerManager virtualController;
    [SerializeField]
    private TutorialManager tutorialManager;
    private bool isMoving = false;
    public bool IsMoving
    {
        get { return isMoving; }
    }
    private bool fn1Enabled = false, leftSwipeEnabled = false, rightSwipeEnabled = false, upSwipeEnabled = false;
    private bool virtualControllerActive = false;

    private void Start()
    {
        if(GetComponent<JMRInteraction>() == null) gameObject.AddComponent<JMRInteraction>();
        m_moveDirection = Vector3.zero;
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
    void Update()
    {
        m_moveDirection = GiveMovementDirection();
    }

    public override Vector3 GiveMovementDirection()
    {
        Vector3 _moveDir;
        if(virtualControllerActive)
        {
            Ray virtualRay = new Ray(virtualController.ControllerMouthPosition, virtualController.gameObject.transform.up);
            Debug.DrawRay(virtualRay.origin, virtualRay.direction, Color.red, 2f);
            if (Physics.Raycast(virtualRay, out RaycastHit hitInfo, maxDistanceOfRay, stadiumLayer))
            {
                var _tempMoveDirection = hitInfo.point - transform.position;
                _moveDir = new Vector3(_tempMoveDirection.x, 0, _tempMoveDirection.z);
                _moveDir.Normalize();
            }
            else
            {
                _moveDir = Vector3.zero;
            }
            return _moveDir;
        }
        if (!isMoving)
        {
            _moveDir = Vector3.zero;
            return _moveDir;
        }
        Ray pointerRay = JMRPointerManager.Instance.GetCurrentRay();
        if (Physics.Raycast(pointerRay, out RaycastHit hit, maxDistanceOfRay, stadiumLayer))
        {

            var _tempMoveDirection = hit.point - transform.position;
            _moveDir = new Vector3(_tempMoveDirection.x, 0, _tempMoveDirection.z);
            _moveDir.Normalize();
        }
        else
        {
            _moveDir = Vector3.zero;
        }
        return _moveDir;

    }

    public override void StopStartMovementAlternatively()
    {
        Debug.Log("Fn1 pressed");
        if (isMoving)
            isMoving = false;
        else
            isMoving = true;
    }

    public override void GoToBalanceMode()
    {
        Debug.Log("Balance Mode");
        SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode.UP_SWIPE, gameObject);
    }
    public override void GoToAttackMode()
    {
        Debug.Log("Attack Mode");
        SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode.RIGHT_SWIPE, gameObject);
    }
    public override void GoToDefenceMode()
    {
        Debug.Log("Defence Mode");
        SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode.LEFT_SWIPE, gameObject);
    }

    public void DisableFN1()
    {
        fn1Enabled = false;

    }
    public void DisableLeftSwipe()
    {
        leftSwipeEnabled = false;
    }
    public void DisableRightSwipe()
    {
        rightSwipeEnabled = false;
    }
    public void DisableUpSwipe()
    {
        upSwipeEnabled = false;
    }
    public void EnableFN1()
    {
        Debug.Log("FN1 enabled");
        fn1Enabled = true;
    }
    public void EnableLeftSwipe()
    {
        leftSwipeEnabled = true;
    }
    public void EnableRightSwipe()
    {
        rightSwipeEnabled = true;
    }
    public void EnableUpSwipe()
    {
        upSwipeEnabled = true;
    }
    public void EnableVirtualController()
    {
        virtualControllerActive = true;
    }
    public void DisableVirtualController()
    {
        virtualControllerActive = false;
    }
    public void EnableMovement()
    {
        Debug.Log("Enable movement called");
        isMoving = true;
    }
    public void DisbleMovement()
    {
        Debug.Log("Disable ovement called");
        isMoving = false;
    }

    /// <summary>
    //This Section is for taking all kind of Controller inputs and delegating to the concerned classes
    /// </summary>
    /// 

    public void OnFn1Action()
    {
        tutorialManager.OnFn1Action();
        if (!fn1Enabled)
            return;
        StopStartMovementAlternatively();
    }
    public void OnSwipeLeft(SwipeEventData eventData, float value)
    {
        tutorialManager.OnSwipeLeft();
        if (!leftSwipeEnabled)
            return;
        GoToDefenceMode();
    }

    public void OnSwipeRight(SwipeEventData eventData, float value)
    {
        tutorialManager.OnSwipeRight();
        if (!rightSwipeEnabled)
        {
            return;
        }
        GoToAttackMode();
    }
    public void OnSwipeUp(SwipeEventData eventData, float value)
    {
        tutorialManager.OnSwipeUp();
        if (!upSwipeEnabled)
        {
            return;
        }
        GoToBalanceMode();
    }

    public void OnSwipeDown(SwipeEventData eventData, float value)
    {
    }

    public void OnSwipeStarted(SwipeEventData eventData)
    {
    }

    public void OnSwipeUpdated(SwipeEventData eventData, Vector2 swipeData)
    {
    }

    public void OnSwipeCompleted(SwipeEventData eventData)
    {
    }

    public void OnSwipeCanceled(SwipeEventData eventData)
    {
    }

}


