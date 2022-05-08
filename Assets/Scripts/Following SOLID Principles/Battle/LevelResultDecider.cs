using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResultDecider : ResultDecider
{
    public delegate void ResultDecideHandler(Result _result, string _levelID);
    public static event ResultDecideHandler OnResultDecided;
    [SerializeField] private string levelID;
    protected override void DecideResult(GameObject _gameObject)
    {
        if(_gameObject == Player)
        {
            PlayerLostEvent.Raise();
            OnResultDecided?.Invoke(Result.PLAYER_LOST, levelID);
            return;
        }
        if(_gameObject == Enemy)
        {
            PlayerWonEvent.Raise();
            OnResultDecided?.Invoke(Result.PLAYER_WON, levelID);
        }
    }
}
