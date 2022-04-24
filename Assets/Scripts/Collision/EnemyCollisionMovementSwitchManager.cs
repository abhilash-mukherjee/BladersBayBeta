using System.Collections;
using UnityEngine;

public class EnemyCollisionMovementSwitchManager : CollisionMovementSwitchManager
{
    private bool m_isCoroutineRunning = false;
    private IEnumerator m_coroutine;
    protected override void HandleCollision()
    {
        if (m_isCoroutineRunning)
        {
            Debug.Log("Collision Movement manager was already active. Reactivated");
            collisionMovementManager.enabled = false;
            collisionMovementManager.enabled = true;
            ordinaryMovementManager.enabled = false;
            StopCoroutine(m_coroutine);
            Debug.Log("Coroutine paused");
            m_coroutine = EndCollsion(movementControlSwitchTime);
            StartCoroutine(m_coroutine);
        }
        else
        {
            collisionMovementManager.enabled = true;
            ordinaryMovementManager.enabled = false;
            m_coroutine = EndCollsion(movementControlSwitchTime);
            StartCoroutine(m_coroutine);

        }
    }
    IEnumerator EndCollsion(float _endTime)
    {
        m_isCoroutineRunning = true;
        yield return new WaitForSeconds(_endTime);
        collisionMovementManager.enabled = false;
        ordinaryMovementManager.enabled = true;
        m_isCoroutineRunning = false;
    }
}