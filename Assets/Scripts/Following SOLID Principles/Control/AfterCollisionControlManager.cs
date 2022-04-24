using System.Collections;
using UnityEngine;

public abstract class AfterCollisionControlManager : MonoBehaviour
{
    [SerializeField]
    private OrdinaryVelocityDeciderControl ordinaryMoverControl;
    [SerializeField]
    private CollisionVelocityDecierControl collisionMoverControl;
    [SerializeField]
    private float controlCeaseTime = 1f;
    protected float ControlCeaseTime { get => controlCeaseTime; }
    protected OrdinaryVelocityDeciderControl OrdinaryMoverControl { get => ordinaryMoverControl; set => ordinaryMoverControl = value; }
    protected CollisionVelocityDecierControl CollisionMoverControl { get => collisionMoverControl; set => collisionMoverControl = value; }

    private void Awake()
    {
        OrdinaryMoverControl.Value = 1f;
        CollisionMoverControl.Value = 0f;
    }
    private void OnEnable()
    {
        CollisionPhysicsResponder.OnControlChanged += OnCollided;
    }
    private void OnDisable()
    {
        CollisionPhysicsResponder.OnControlChanged -= OnCollided;
        
    }
    private void OnCollided(GameObject obj)
    {
        if (obj != gameObject) return;
        OrdinaryMoverControl.Value = 0f;
        CollisionMoverControl.Value = 1f;
        StartCoroutine(SwitchControl());
    }
    protected abstract IEnumerator SwitchControl();

}
