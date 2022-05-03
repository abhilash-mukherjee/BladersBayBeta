using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDecider : MonoBehaviour
{
    [SerializeField]
    private GameObject player, enemy;
    [SerializeField]
    private GameEvent playerWonEvent, playerLostEvent;
    private void OnEnable()
    {
        HealthManager.OnDied += DecideResult;
    }
    private void OnDisable()
    {
        HealthManager.OnDied -= DecideResult;
        
    }

    private void DecideResult(GameObject _gameObject)
    {
        if(_gameObject == player)
        {
            playerLostEvent.Raise();
            return;
        }
        if(_gameObject == enemy)
        {
            playerWonEvent.Raise();
        }
    }
}
