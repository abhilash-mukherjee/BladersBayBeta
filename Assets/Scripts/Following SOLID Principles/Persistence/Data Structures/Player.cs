using System;
using UnityEngine;

[Serializable]
public class Player: Base
{
    public delegate void PlayerDataChangeHandler(string _id);
    public static event PlayerDataChangeHandler OnPlayerDataChanged;
    [SerializeField]private string playerName;
    [SerializeField]private string modelName;
    [SerializeField] private string model, icon, avatar;
    public string PlayerName
    { 
        get => playerName; set
        {
            playerName = value;
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

    public string ModelKey { get => model; }
    public string IconKey { get => icon; }
    public string AvatarKey { get => avatar; }

    public Player(Player _player)
    {
        modelName = _player.ModelName;
        playerName = _player.PlayerName;
        model = _player.ModelKey;
        avatar = _player.AvatarKey;
        icon = _player.IconKey;
        ID = _player.ID;
        Debug.Log($"Model = {model}");
        Debug.Log($"icon = {icon}");
        Debug.Log($"avatar = {avatar}");
    }

    public void SetModel(string _model)
    {
        model = _model;
        OnPlayerDataChanged?.Invoke(ID);
    }
    public void SetBeyBladeIcon(string _beyBladeIcon)
    {
        icon = _beyBladeIcon;
        OnPlayerDataChanged?.Invoke(ID);
    }
    public void SetAvatar(string _avatar)
    {
        avatar = _avatar;
        OnPlayerDataChanged?.Invoke(ID);
    }
    public GameObject GetModel()
    {
        return GameAssets.Instance.LoadGameObject(model);
    }
    public Sprite GetBeyBladeIcon()
    {
        return GameAssets.Instance.LoadIconSprite(icon);
    }
    public Sprite GetAvatar()
    {
        return GameAssets.Instance.LoadAvatarSprite(avatar);
    }
}

