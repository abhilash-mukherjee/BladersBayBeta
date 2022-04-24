using System;
using UnityEngine;

public class BeyBladeModeAvailabilityManager : MonoBehaviour
{
    public delegate void PostCollisionModeAvailabilityHandler(string _uID, GameObject _gameObject,INormalCollision _collision);
    public static event PostCollisionModeAvailabilityHandler OnCollided;
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected StateData beyBladeValues;


    private void Awake()
    {
        CollisionManager1.OnBeyBladesCollidedNormally += HandleModeAvailabilityAfterCollision;
    }

    private void OnDisable()
    {
        CollisionManager1.OnBeyBladesCollidedNormally -= HandleModeAvailabilityAfterCollision;
    }

 

    private void HandleModeAvailabilityAfterCollision(INormalCollision _Collision)
    {
        if (_Collision.IsAttacker(gameObject) == false && _Collision.IsVictim(gameObject) == false)
        {
            Debug.Log("Neither Attacker Nor Victim");
            return;
        }
        OnCollided?.Invoke(gameObject.GetComponent<BeyBladeTag>().UID, this.gameObject, _Collision);
    }
  

}

