using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private BeyBladeData initialPlayerData;
    public static GameDataManager Instance;
    private GameData m_gameData;
    private SerializablePlayerData m_playerData;
    public GameData GameData { get => m_gameData; set => m_gameData = value; }
    public SerializablePlayerData PlayerData { 
        get 
        {
            return m_playerData;
        } 
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        m_gameData = new GameData(0);
        m_playerData = new SerializablePlayerData(initialPlayerData);
    }

    private void OnEnable()
    {
        CoinPerk.OnCoinsAdded += (int _count) => GameData.CoinCount += _count;

    }
    private void OnDisable()
    {
        CoinPerk.OnCoinsAdded -= (int _count) => GameData.CoinCount += _count;
        
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

[Serializable]
public class SerializablePlayerData
{
    public delegate void PlayerDataChangeHandler();
    public static event PlayerDataChangeHandler OnPlayerDataChanged;

    private string playerName;
    private GameObject model;
    private Sprite icon;
    private Sprite playerAvatar;
    private string modelName;

    public string ModelName
    {
        get => modelName;
        set
        {
            modelName = value;
            OnPlayerDataChanged?.Invoke();
        }
    }
    public string PlayerName
    {
        get => playerName;
        set
        {
            playerName = value;
            Debug.Log("Name Changed to " + value);
            OnPlayerDataChanged?.Invoke();
        }
    }
    public GameObject Model
    {
        get => model;
        set
        {
            model = value;
            OnPlayerDataChanged?.Invoke();
        }
    }
    public Sprite Icon
    {
        get => icon;
        set
        {
            icon = value;
            OnPlayerDataChanged?.Invoke();
        }
    }
    public Sprite PlayerAvatar
    {
        get => playerAvatar;
        set
        {
            playerAvatar = value;
            OnPlayerDataChanged?.Invoke();
        }
    }
    public SerializablePlayerData(BeyBladeData beyBladeData)
    {
        model = beyBladeData.Model;
        icon = beyBladeData.Icon;
        modelName = beyBladeData.ModelName;
    }
   
}
