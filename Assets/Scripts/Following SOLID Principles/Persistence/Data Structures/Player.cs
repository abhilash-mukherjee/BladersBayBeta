using System;
using UnityEngine;

[Serializable]
public class Player: Base
{
    public delegate void PlayerDataChangeHandler(string _id);
    public static event PlayerDataChangeHandler OnPlayerDataChanged;
    [SerializeField]private string playerName;
    [SerializeField]private GameObject model;
    [SerializeField]private Sprite icon;
    [SerializeField]private Sprite playerAvatar;
    [SerializeField]private string modelName;
    public string PlayerName
    { 
        get => playerName; set
        {
            playerName = value;
            OnPlayerDataChanged?.Invoke(ID);
        } 
    }
    public GameObject Model
    {
        get => model;
        set
        {
            model = value;
            OnPlayerDataChanged?.Invoke(ID);
        }
    }
    public Sprite Icon
    {
        get => icon;
        set
        {
            icon = value;
            OnPlayerDataChanged?.Invoke(ID);
        }
    }
    public Sprite PlayerAvatar
    {
        get => playerAvatar;
        set
        {
            playerAvatar = value;
            OnPlayerDataChanged?.Invoke(ID);
        }
    }
    public string ModelName
    {
        get => modelName;
        set
        {
            modelName = value;
            OnPlayerDataChanged?.Invoke(ID);
        }
    }
    public Player(BeyBladeData _playerData)
    {
        modelName = _playerData.ModelName;
        playerName = _playerData.PlayerName;
        model = _playerData.Model;
        icon = _playerData.Icon;
        playerAvatar = _playerData.PlayerAvatar;
    }
}

