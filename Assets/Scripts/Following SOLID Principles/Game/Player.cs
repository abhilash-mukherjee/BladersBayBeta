using System;
using UnityEngine;

[Serializable]
public class Player: Base
{
    public delegate void PlayerDataChangeHandler(string _id);
    public static event PlayerDataChangeHandler OnPlayerDataChanged;
    public string playerName;
    public GameObject model;
    public Sprite icon;
    public Sprite playerAvatar;
    public string modelName;
    public string PlayerName { 
        get => playerName; set
        {
            playerName = value;
            OnPlayerDataChanged?.Invoke(id);
        } 
    }
    public GameObject Model
    {
        get => model;
        set
        {
            model = value;
            OnPlayerDataChanged?.Invoke(id);
        }
    }
    public Sprite Icon
    {
        get => icon;
        set
        {
            icon = value;
            OnPlayerDataChanged?.Invoke(id);
        }
    }
    public Sprite PlayerAvatar
    {
        get => playerAvatar;
        set
        {
            playerAvatar = value;
            OnPlayerDataChanged?.Invoke(id);
        }
    }
    public string ModelName
    {
        get => modelName;
        set
        {
            modelName = value;
            OnPlayerDataChanged?.Invoke(id);
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

