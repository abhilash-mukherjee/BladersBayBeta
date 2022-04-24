using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionManager1 : MonoBehaviour
{
    public delegate void BeyBladeCollisionHealthHandler(INormalCollision _collision);
    public delegate void CollisionPhysicsHandler(IBasicCollision _collision);
    public delegate void CollisionStartEndHandler(IBasicCollision _collision);
    public static event BeyBladeCollisionHealthHandler OnBeyBladesCollidedNormally;
    public static event CollisionPhysicsHandler OnCollisionPhysicsCalculated;
    public static event CollisionStartEndHandler OnCollisionStarted;
    public static event CollisionStartEndHandler OnCollisionEnded;
    [SerializeField]
    private List<BeyBladeCollisionType> collisionTypes = new List<BeyBladeCollisionType>();
    [SerializeField]
    private float timeGapBetweenTwoCollisions= 1f;
    [SerializeField]
    private Collider player1Collider, player2Collider;
    [SerializeField]
    private string beybladeHitSound= "BeyBladeClash";
    [SerializeField]
    private GameObject collisionSpark;
    [SerializeField]
    private float collisionVelocityMultiplier;
    [SerializeField]
    [Tooltip("Minimum velocity possessed by a beyblade below which beyblade is considered static while colliding")]
    private float staticCollisionVelocityLimit;
    [SerializeField]
    [Tooltip("Multiplying factor to a beyblade's final velocity after collision when it is static")]
    private float staticCollisionVelocityMultiplier = 0.1f;
    [SerializeField]
    private float safeDistanceForGlitchFreeBehaviour = 0.18f;
    private INormalCollision m_normalCollision;
    private IGlitchyCollision m_glitchyCollision;
    private bool m_isCollisionPhaseOn = false;
    private bool m_isCollisionGlitchPhaseOn = false;

    void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        if (player1Collider.bounds.Intersects(player2Collider.bounds))
        {
            if (m_isCollisionGlitchPhaseOn)
                return ;
            if (CheckForGlitch())
            {
                StartCoroutine(TurnOffCollisionGlitchPhaseAfterGivenTime(timeGapBetweenTwoCollisions));
                return;
            }
            if (m_isCollisionPhaseOn)
                return;
            Instantiate(collisionSpark, (player1Collider.gameObject.transform.position + player2Collider.gameObject.transform.position) / 2f, Quaternion.identity);
            GameAudioManager.Instance.PlaySoundOneShot(beybladeHitSound);
            Debug.Log("After audio played");
            m_normalCollision = new BeyBladeCollision(player1Collider.gameObject, player2Collider.gameObject, collisionTypes, collisionVelocityMultiplier,
                staticCollisionVelocityLimit, staticCollisionVelocityMultiplier);            
            Debug.Log("After collision object instantiantiated");
            //Physics Calculation Event must be triggered prior to starting the collision phase, or else movement will lag

            //Physics Calculation
            if (OnCollisionPhysicsCalculated != null)
                OnCollisionPhysicsCalculated.Invoke(m_normalCollision);
            else Debug.Log("No recievers");
            OnBeyBladesCollidedNormally?.Invoke(m_normalCollision);
            //Start Collision Phase
            OnCollisionStarted?.Invoke(m_normalCollision);
            m_isCollisionPhaseOn = true;
            StartCoroutine(TurnOffCollisionPhaseAfterGivenTime(timeGapBetweenTwoCollisions));
        }
    }

    private bool CheckForGlitch()
    {
        if (Vector3.Distance(player1Collider.transform.position, player2Collider.transform.position) <= safeDistanceForGlitchFreeBehaviour)
        {
            Debug.Log("Gltch occured");
            m_glitchyCollision = new BeyBladeCollisionGlitch(player1Collider.gameObject, player2Collider.gameObject);
            //Physics Calculation Event must be triggered prior to starting the collision phase, or else movement will lag

            //Physics Calculation
            OnCollisionPhysicsCalculated?.Invoke(m_glitchyCollision);
            //Start Collision Phase
            OnCollisionStarted?.Invoke(m_glitchyCollision);
            m_isCollisionGlitchPhaseOn = true;
            return true;
        }
        else return false;

    }

    IEnumerator TurnOffCollisionPhaseAfterGivenTime(float _timeGapBetweenTwoCollisions)
    {
        yield return new WaitForSeconds(_timeGapBetweenTwoCollisions);
        OnCollisionEnded?.Invoke(m_normalCollision);
        m_isCollisionPhaseOn = false;
    }
    IEnumerator TurnOffCollisionGlitchPhaseAfterGivenTime(float _timeGapBetweenTwoCollisions)
    {
        GameAudioManager.Instance.PlaySoundOneShot(beybladeHitSound);
        yield return new WaitForSeconds(_timeGapBetweenTwoCollisions);
        OnCollisionEnded?.Invoke(m_glitchyCollision);
        m_isCollisionGlitchPhaseOn = false;
    }
}
