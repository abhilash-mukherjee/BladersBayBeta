using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
    protected abstract void Move();
    private void Update()
    {
        Move();
    }
}
