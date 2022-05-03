using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    private GameData m_gameData;

    public GameData GameData { get => m_gameData; set => m_gameData = value; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        CoinPerk.OnCoinsAdded += (int _count) => GameData.CoinCount += _count;
    }
    private void OnDisable()
    {
        CoinPerk.OnCoinsAdded -= (int _count) => GameData.CoinCount += _count;
        
    }
    private void Start()
    {
        m_gameData = new GameData(0);
    }
}

[System.Serializable]
public class GameData
{
    public int CoinCount { get => m_coinCount; set => m_coinCount = value; }

    private int m_coinCount;
    public GameData(int _coinCount)
    {
        m_coinCount = _coinCount;
    }
}